<script>
    import { shopItems } from '../stores/apiDataProvider.js';
    import ItemCard from './ItemCard.svelte';
    import Section from './sections/Section.svelte';
    export let type;
</script>

<Section name={type.name}>
    <div class="items-container">
        {#each $shopItems as item}
            {#if item.type.id === type.id}
                <ItemCard fooditem={item} />
            {/if}
        {:else}
            <p>loading...</p>
        {/each}
    </div>
</Section>

<style>
    .items-container {
        display: grid;
        gap: 1rem;
        grid-template-columns: repeat(auto-fill, minmax(292px, 1fr));
    }
</style>
