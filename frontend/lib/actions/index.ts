"use server";

import { revalidatePath } from "next/cache";
import toast from "react-hot-toast";
import { getAveragePrice, getHighestPrice, getLowestPrice } from "../utils";
import { generateEmailBody, sendEmail } from "../nodemailer";
import { Product, User } from "@/types";
import axios from "axios";

export async function getProductById(productId: string) {
    try {
        const response = await axios.get(
            `http://localhost:5234/product/${productId}`
        );
        const product = response.data as Product;

        return product;
    } catch (error: any) {
        console.log(`Failed to get product: ${error.message}`);
    }
}

export async function getAllProducts() {
    try {
        const response = await axios.get("http://localhost:5234/product");
        const products = response.data as Product[];

        return products;
    } catch (error: any) {
        console.log(`Failed to get products: ${error.message}`);
    }
}

export async function scrape(url: string) {
    try {
        const response = await axios.post(
            `http://localhost:5234/product/scrape`,
            { url }
        );
        const product = response.data as Product;

        return product;
    } catch (error: any) {
        console.log(`Failed to scrape product: ${error.message}`);
    }
}

export async function getSimilarProducts(productId: string) {
    try {
        const response = await axios.get(
            `http://localhost:5234/product/${productId}/similar`
        );
        const similarProducts = response.data as Product[];

        return similarProducts;
    } catch (error: any) {
        console.log(`Failed to get product: ${error.message}`);
    }
}

export async function addUserEmailToProduct(
    productId: string,
    userEmail: string
) {
    try {
        const response = await axios.post(
            `http://localhost:5234/product/email/${productId}`,
            { email: userEmail }
        );

        const product = response.data as Product;
        return product;
    } catch (error: any) {
        console.log(`Failed to get product: ${error.message}`);
    }
}
