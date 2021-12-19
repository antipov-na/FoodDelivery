<script>
    import ItemCardAdmin from './ItemCardAdmin.svelte';

    export let type;
    export let items;

    let isColapsed = false;
</script>

<div class="category-header">
    <h2>
        {type.name}
    </h2>
    <span on:click={() => (isColapsed = !isColapsed)} class="colapse-btn">[свернуть]</span>
</div>

<div class:colapsed={isColapsed} class="container">
    {#each items as item}
        {#if item.type.id === type.id}
            <ItemCardAdmin on:deleteItem fooditem={item} />
        {/if}
    {/each}
</div>

<style>
    .category-header {
        display: flex;
        gap: 10px;
        align-items: center;
    }
    .container {
        display: grid;
        grid-auto-rows: 1fr;
        gap: 1rem;
        grid-template-columns: repeat(auto-fill, minmax(292px, 1fr));
    }
    .colapse-btn {
        color: orange;
        cursor: pointer;
    }
    .colapsed {
        display: none;
    }
</style>
