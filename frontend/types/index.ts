export type PriceHistoryItem = {
    price: number;
    date: Date;
};

export type User = {
    email: string;
};

export type Product = {
    id: string;
    url: string;
    title: string;
    category: string;
    description: string;
    imageUrl: string;
    currency: string;
    priceHistory: PriceHistoryItem[];
    reviewCount: number;
    avgRating: number;
    outOfStock: Boolean;
    userEmail: string;
    user?: User;
};

export type NotificationType =
    | "WELCOME"
    | "CHANGE_OF_STOCK"
    | "LOWEST_PRICE"
    | "THRESHOLD_MET";

export type EmailContent = {
    subject: string;
    body: string;
};

export type EmailProductInfo = {
    title: string;
    url: string;
};
