export type ShopItem = {
    id: number;
    name: string;
    description: string;
    type: ItemType;
    price: number;
    image: Image;
};

export type ItemType = {
    id: number;
    name: string;
};

export type Image = {
    id: string;
    url: string;
};
