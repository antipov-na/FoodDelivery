<script>
    import DeliveryAndPaymentSection from '../components/sections/DeliveryAndPaymentSection.svelte';
    import { itemTypes, shopItems } from '../stores/apiDataProvider.js';
    import ShopCategory from '../components/ShopCategory.svelte';
    import RecomendationsSection from '../components/sections/RecomendationSection.svelte';
    let promice1 = shopItems.get();
    let promice2 = itemTypes.get();
</script>

<div class="container">
    {#await promice1 then _}
        <RecomendationsSection shopItems={$shopItems} />
    {/await}
    {#await promice2 then _}
        {#each $itemTypes as group}
            <ShopCategory type={group} />
        {/each}
    {/await}

    <DeliveryAndPaymentSection />
</div>
