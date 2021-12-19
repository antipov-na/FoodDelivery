<script>
    export let fooditem;
</script>

<div class="card">
    <div class="card__top">
        <img src={fooditem.image.url} alt="" />
        <p class="card__name">{fooditem.name}</p>
        <p class="card__descriprion">{fooditem.description}</p>
    </div>
    <div class="card__bottom">
        <p class="card__price">{fooditem.price} p.</p>
    </div>
</div>

<style>
    .card {
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
        font-weight: 500;
        margin: 0 0 10px 0;
    }

    .card__price {
        margin: 0;
        font-weight: 400;
        font-size: 24px;
    }

    .card__descriprion {
        margin: 0;
        font-size: 14px;
        line-height: 20px;
        color: #5c6370;
    }
    img {
        width: 100%;
        height: auto;
    }
</style>
