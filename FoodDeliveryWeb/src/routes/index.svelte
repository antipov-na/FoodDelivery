<script>
    import DeliveryAndPaymentSection from '../components/sections/DeliveryAndPaymentSection.svelte';
    import { itemTypes } from '../stores/apiDataProvider.js';
    import ShopCategory from '../components/ShopCategory.svelte';
    import RecomendationsSection from '../components/sections/RecomendationSection.svelte';
</script>

<div class="container">
    <RecomendationsSection />
    {#each $itemTypes as group}
        <ShopCategory type={group} />
    {/each}
    <DeliveryAndPaymentSection />
</div>
