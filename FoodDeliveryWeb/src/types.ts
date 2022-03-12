export interface ShopItem {
    id: number;
    name: string;
    description: string;
    type: ItemType;
    price: number;
    image: Image;
}

export interface CreateShopItemDto {
    name: string;
    description: string;
    type: number;
    price: number;
    image: string;
}

export interface EditShopItemDto extends CreateShopItemDto {
    id: number;
    name: string;
    description: string;
    type: number;
    price: number;
    image: string;
}

export interface ItemType {
    id: number;
    name: string;
}

export interface EditItemTypeDto extends ItemType {}

export interface Image {
    id: string;
    url: string;
}

export interface EditImageDto extends Image {}
