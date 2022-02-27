const baseUrl = 'https://localhost:44384/api';

import { writable } from 'svelte/store';

export const shopItems = createShopItems();

function createShopItems() {
    const { subscribe, set, update } = writable([]);

    return {
        subscribe,
        add: async (item) => {
            let data = new FormData();
            data.append('name', item.name);
            data.append('description', item.description);
            data.append('typeId', item.type);
            data.append('price', item.price);
            data.append('imageId', item.image);
            const response = await fetch(`${baseUrl}/shopItems`, {
                method: 'POST',
                headers: {
                    Authorization: `Bearer `
                },
                body: data
            });
            if (response.ok) {
                shopItems.get();
            } else {
                console.log(response);
            }
        },
        delete: async (id) => {
            const response = await fetch(`${baseUrl}/shopItems/${id}`, {
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
        update: async (item) => {
            let data = new FormData();
            data.append('id', item.id);
            data.append('name', item.name);
            data.append('description', item.description);
            data.append('typeId', item.type.id);
            data.append('price', item.price);
            data.append('imageId', item.image.id);

            const response = await fetch(`${baseUrl}/shopItems/`, {
                method: 'PUT',
                headers: {
                    Authorization: `Bearer `
                },
                body: data
            });
            if (response.ok) {
                shopItems.get();
            } else {
                console.log(response);
            }
        },
        get: async () => {
            const response = await fetch(`${baseUrl}/shopItems`, {
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
        add: async (item) => {
            let data = new FormData();
            data.append('name', item.name);
            const response = await fetch(`${baseUrl}/shopItemTypes`, {
                method: 'POST',
                headers: {
                    Authorization: `Bearer `
                },
                body: data
            });
            if (response.ok) {
                itemTypes.get();
            } else {
                console.log(response);
            }
        },
        delete: async (id) => {
            const response = await fetch(`${baseUrl}/shopItemTypes/${id}`, {
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
        update: async (item) => {
            let data = new FormData();
            data.append('id', item.id);
            data.append('name', item.name);
            const response = await fetch(`${baseUrl}/shopItemTypes`, {
                method: 'PUT',
                headers: {
                    Authorization: `Bearer `
                },
                body: data
            });
            if (response.ok) {
                itemTypes.get();
            } else {
                console.log(response);
            }
        },
        get: async () => {
            const response = await fetch(`${baseUrl}/shopItemTypes`, {
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
            let data = new FormData();
            data.append('image', item);
            const response = await fetch(`${baseUrl}/images`, {
                method: 'POST',
                headers: {
                    Authorization: `Bearer `
                },
                body: data
            });
            if (response.ok) {
                images.get();
            } else {
                console.log(response);
            }
        },
        delete: async (id) => {
            const response = await fetch(`${baseUrl}/images/${id}`, {
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
            const response = await fetch(`${baseUrl}/images`, {
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
