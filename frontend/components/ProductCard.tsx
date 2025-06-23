import { Product } from "@/types";
import Image from "next/image";
import Link from "next/link";
import React from "react";

interface Props {
  product: Product;
}

const ProductCard = ({ product }: Props) => {
  const { price } = product.priceHistory[0];

  return (
    <Link href={`/products/${product.id}`} className="product-card">
      <div className="product-card_img-container">
        <Image
          src={product.imageUrl}
          alt={product.title}
          width={200}
          height={200}
          className="product-card_img"
        />
      </div>

      <div className="flex flex-col gap-3">
        <h3 className="product-title">{product.title}</h3>

        <div className="flex justify-between">
          <p className="text-black text-lg font-semibold">
            <span>{product.currency}</span>
            <span>{price}</span>
          </p>
        </div>
      </div>
    </Link>
  );
};

export default ProductCard;
