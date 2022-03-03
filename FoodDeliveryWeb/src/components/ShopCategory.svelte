<script>
    import { shopItems } from '../stores/apiDataProvider.js';
    import ItemCard from './ItemCard.svelte';
    import Section from './sections/Section.svelte';
    export let type;
    let promice = shopItems.get();
</script>

<Section name={type.name}>
    <div class="items-container">
        {#await promice then _}
            {#each $shopItems as item}
                {#if item.type.id === type.id}
                    <ItemCard fooditem={item} />
                {/if}
            {/each}
        {/await}
    </div>
</Section>

<style>
    .items-container {
        display: grid;
        gap: 1rem;
        grid-template-columns: repeat(auto-fill, minmax(292px, 1fr));
    }
</style>
