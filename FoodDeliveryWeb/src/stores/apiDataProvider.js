const baseUrl = 'https://localhost:44384/api';

import { writable } from 'svelte/store';

export const shopItems = createShopItems();
shopItems.getItems();

function createShopItems() {
    const { subscribe, set, update } = writable([]);

    return {
        subscribe,
        addItem: async (item) => {
            const response = await fetch(baseUrl + '/' + 'shopItems', {
                method: 'POST',
                body: item
            });
            if (response.ok) {
                this.getItems();
            } else {
                console.log(response);
            }
        },
        deleteItem: async (id) => {
            const response = await fetch(baseUrl + '/' + 'shopItems' + '/' + id, {
                method: 'DELETE'
            });
            if (response.ok) {
                update((i) => i.filter((item) => item.id !== id));
            } else {
                console.log(response);
            }
        },
        updateItem: async (item) => {
            const response = await fetch(baseUrl + '/' + 'shopItems' + '/' + item.id, {
                method: 'PUT',
                body: item
            });
            if (response.ok) {
                this.getItems();
            } else {
                console.log(response);
            }
        },
        getItems: async () => {
            console.log(baseUrl + '/' + 'shopItems');
            const response = await fetch(baseUrl + '/' + 'shopItems', {
                method: 'GET'
            });
            if (response.ok) {
                set(await response.json());
            } else {
                console.log(response);
            }
        }
    };
}

export const itemTypes = createItemTypes();
itemTypes.getItemTypes();

function createItemTypes() {
    const { subscribe, set, update } = writable([]);

    return {
        subscribe,
        addItemType: async (item) => {
            const response = await fetch(baseUrl + '/' + 'shopItemTypes', {
                method: 'POST',
                body: item
            });
            if (response.ok) {
                const response = await fetch(baseUrl, {
                    method: 'GET'
                });
                set(await response.json());
            } else {
                console.log(response);
            }
        },
        deleteItemType: async (id) => {
            console.log(baseUrl + '/' + id);
            const response = await fetch(baseUrl + '/' + 'shopItemTypes' + '/' + id, {
                method: 'DELETE'
            });
            if (response.ok) {
                update((i) => i.filter((item) => item.id !== id));
            } else {
                console.log(response);
            }
        },
        updateItemType: async (item) => {
            const response = await fetch(baseUrl + '/' + 'shopItemTypes' + '/' + item.id, {
                method: 'PUT',
                body: item
            });
            if (response.ok) {
                this.getItemTypes();
            } else {
                console.log(response);
            }
        },
        getItemTypes: async () => {
            const response = await fetch(baseUrl + '/' + 'shopItemTypes', {
                method: 'GET'
            });
            if (response.ok) {
                set(await response.json());
            } else {
                console.log(response);
            }
        }
    };
}
