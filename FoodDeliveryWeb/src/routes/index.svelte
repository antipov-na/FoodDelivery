<script lang="ts" context="module">
    import type { ShopItem, ItemType } from '../types';
    export async function load({ fetch }) {
        const shopItems: ShopItem[] = await (await fetch('https://localhost:44384/api/shopItems/')).json();
        const itemTypes: ItemType[] = await (await fetch('https://localhost:44384/api/shopItemTypes/')).json();
        return {
            props: { shopItems, itemTypes }
        };
    }
</script>

<script lang="ts">
    import DeliveryAndPaymentSection from '../components/sections/DeliveryAndPaymentSection.svelte';
    import ShopCategory from '../components/ShopCategory.svelte';
    import RecomendationsSection from '../components/sections/RecomendationSection.svelte';

    export let shopItems: ShopItem[];
    export let itemTypes: ItemType[];
</script>

<div class="container">
    <RecomendationsSection {shopItems} />
    {#each itemTypes as group}
        <ShopCategory type={group} {shopItems} />
    {/each}
    <DeliveryAndPaymentSection />
</div>
