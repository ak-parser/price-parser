"use server";

import { revalidatePath } from "next/cache";
import toast from "react-hot-toast";
import Product, { ProductModel } from "../models/product-model";
import { connectToDB } from "../mongoose";
import { scrapeProduct } from "../scraper";
import { getAveragePrice, getHighestPrice, getLowestPrice } from "../utils";
import { generateEmailBody, sendEmail } from "../nodemailer";
import { User } from "@/types";
import axios from "axios";

export async function scrapeAndStoreProduct(productUrl: string) {
    if (!productUrl) return;

    try {
        connectToDB();

        const scrapedProduct = await scrapeProduct(productUrl);

        if (!scrapedProduct) return;

        let product = scrapedProduct;

        const existingProduct = await Product.findOne({
            url: scrapedProduct.url,
        });

        if (existingProduct) {
            const updatedPriceHistory: any = [...existingProduct.priceHistory, { price: scrapedProduct.currentPrice }];

            product = {
                ...scrapedProduct,
                priceHistory: updatedPriceHistory,
                lowestPrice: getLowestPrice(updatedPriceHistory),
                highestPrice: getHighestPrice(updatedPriceHistory),
                averagePrice: getAveragePrice(updatedPriceHistory),
            };
        }

        const newProduct = await Product.findOneAndUpdate({ url: scrapedProduct.url }, product, {
            upsert: true,
            new: true,
        });

        revalidatePath(`/products/${newProduct._id}`);
        // redirect to product page
    } catch (error: any) {
        toast.error(`Failed to create/update product: ${error.message}`);
    }
}

export async function getProductById(productId: string) {
    try {
        const response = await axios.get(`http://localhost:5234/product/${productId}`);
        const product = response.data as ProductModel;

        console.log(product);
        return product;
    } catch (error: any) {
        console.log(`Failed to get product: ${error.message}`);
    }
}

export async function getAllProducts() {
    try {
        const response = await axios.get("http://localhost:5234/product");
        const products = response.data as ProductModel[];

        return products;
    } catch (error: any) {
        console.log(`Failed to get products: ${error.message}`);
    }
}

export async function getSimilarProducts(productId: string) {
    try {
        connectToDB();

        const currentProduct = await Product.findById(productId);

        if (!currentProduct) return null;

        const similarProducts = await Product.find({
            _id: { $ne: productId },
        }).limit(3);

        return similarProducts;
    } catch (error) {
        console.log(error);
    }
}

export async function addUserEmailToProduct(productId: string, userEmail: string) {
    try {
        const product = await Product.findById(productId);

        if (!product) return;

        const userExists = product.users.some((user: User) => user.email === userEmail);

        if (!userExists) {
            product.users.push({ email: userEmail });

            await product.save();

            const emailContent = await generateEmailBody(product, "WELCOME");

            await sendEmail(emailContent, [userEmail]);
        }
    } catch (error) {
        console.log(error);
    }
}
