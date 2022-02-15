<script>
    import { createEventDispatcher } from 'svelte';

    export let shopItemsTypes;
    export let selectedItem = shopItemsTypes[0];

    const dispatch = createEventDispatcher();
</script>

<table class="table">
    <thead class="table-head">
        <tr>
            <th> Id </th>
            <th> Название </th>
        </tr>
    </thead>
    <tbody class="table-body">
        {#each shopItemsTypes as item}
            <tr
                class:selected={item == selectedItem}
                on:click={() => {
                    dispatch('itemClick');
                    selectedItem = item;
                }}
            >
                <td>{item.id}</td>
                <td>{item.name}</td>
            </tr>
        {/each}
    </tbody>
</table>

<style>
    .table {
        table-layout: fixed;
        width: 100%;
        border-collapse: collapse;
        border-radius: 5px 5px 0 0;
        overflow: hidden;
        box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
    }

    .table-head tr {
        background-color: #ff6900;
        color: #ffffff;
    }

    .table-head tr th,
    .table-body tr td {
        padding: 12px 15px;
        overflow: hidden;
        white-space: nowrap;
        text-overflow: ellipsis;
        text-align: left;
    }

    .table-body tr {
        cursor: pointer;
        border-bottom: 1px solid #ddd;
    }

    .table-body tr:nth-last-of-type(even) {
        background-color: #f3f3f3;
    }

    .table-body tr:last-of-type {
        border-bottom: 2px solid #ff6900;
    }

    .table-body tr:hover {
        background-color: #ffeee2;
    }

    .selected {
        background-color: #ffd4b6 !important;
    }
</style>
