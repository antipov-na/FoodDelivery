const baseUrl = 'https://localhost:44384/api';

import { writable } from 'svelte/store';

export const shopItems = createShopItems();

function createShopItems() {
    const { subscribe, set, update } = writable([]);

    return {
        subscribe,
        addItem: async (item) => {
            const response = await fetch(baseUrl + '/' + 'shopItems', {
                method: 'POST',
                headers: {
                    Authorization: `Bearer `
                },
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
                method: 'DELETE',
                headers: {
                    Authorization: `Bearer `
                }
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
                headers: {
                    Authorization: `Bearer `
                },
                body: item
            });
            if (response.ok) {
                this.getItems();
            } else {
                console.log(response);
            }
        },
        getItems: async () => {
            const response = await fetch(baseUrl + '/' + 'shopItems', {
                method: 'GET',
                headers: {
                    Authorization: `Bearer `
                }
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

function createItemTypes() {
    const { subscribe, set, update } = writable([]);

    return {
        subscribe,
        addItemType: async (item) => {
            const response = await fetch(baseUrl + '/' + 'shopItemTypes', {
                method: 'POST',
                headers: {
                    Authorization: `Bearer `
                },
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
            const response = await fetch(baseUrl + '/' + 'shopItemTypes' + '/' + id, {
                method: 'DELETE',
                headers: {
                    Authorization: `Bearer `
                }
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
                headers: {
                    Authorization: `Bearer `
                },
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
                method: 'GET',
                headers: {
                    Authorization: `Bearer `
                }
            });
            if (response.ok) {
                set(await response.json());
            } else {
                console.log(response);
            }
        }
    };
}

export const images = createImages();

function createImages() {
    const { subscribe, set, update } = writable([]);

    return {
        subscribe,
        add: async (item) => {
            const response = await fetch(baseUrl + '/' + 'images', {
                method: 'POST',
                headers: {
                    Authorization: `Bearer `,
                    'Content-Type': 'application/json'
                },
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
        delete: async (id) => {
            const response = await fetch(baseUrl + '/' + 'images' + '/' + id, {
                method: 'DELETE',
                headers: {
                    Authorization: `Bearer `
                }
            });
            if (response.ok) {
                update((i) => i.filter((item) => item.id !== id));
            } else {
                console.log(response);
            }
        },
        get: async () => {
            const response = await fetch(baseUrl + '/' + 'images', {
                method: 'GET',
                headers: {
                    Authorization: `Bearer `
                }
            });
            if (response.ok) {
                set(await response.json());
            } else {
                console.log(response);
            }
        }
    };
}
