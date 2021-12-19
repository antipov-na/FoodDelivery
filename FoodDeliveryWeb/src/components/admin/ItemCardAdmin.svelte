<script>
    import { createEventDispatcher } from 'svelte';

    const dispatch = createEventDispatcher();

    export let fooditem;
</script>

<div class="card">
    <span class="delete-btn" on:click={dispatch('deleteItem', fooditem.id)}>x</span>
    <div class="card__top">
        <img src={fooditem.image.url} alt={fooditem.name} />
        <strong class="card__name">{fooditem.name}</strong>
        <p class="card__descriprion">{fooditem.description}</p>
    </div>
    <div class="card__bottom">
        <strong class="card__price">{fooditem.price} p.</strong>
    </div>
</div>

<style>
    .delete-btn {
        top: -10px;
        right: -10px;
        cursor: pointer;
        position: absolute;
        display: block;
        text-align: center;
        border-radius: 100%;
        width: 25px;
        height: 25px;
        background: orange;
    }
    .card {
        position: relative;
        border: 2px solid orange;
        border-radius: 10px;
        display: flex;
        flex-direction: column;
        background-color: white;
        justify-content: space-between;
        padding: 10px;
    }
    .card__top {
        margin-bottom: 10px;
    }
    .card__bottom {
        display: flex;
        justify-content: space-between;
    }
    .card__name {
        font-size: 18px;
    }

    .card__price {
        font-size: 20px;
    }

    .card__descriprion {
        margin: 0;
        font-size: 12px;
    }
    img {
        width: 100%;
        height: auto;
    }
</style>
