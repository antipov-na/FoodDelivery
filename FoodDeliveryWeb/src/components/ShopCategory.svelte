<script>
    import ItemCard from './ItemCard.svelte';
    import Section from './sections/Section.svelte';
    export let type;
    export let shopItems;
</script>

<Section name={type.name}>
    <div class="items-container">
        {#each shopItems as item}
            {#if item.type.id === type.id}
                <ItemCard fooditem={item} />
            {/if}
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
