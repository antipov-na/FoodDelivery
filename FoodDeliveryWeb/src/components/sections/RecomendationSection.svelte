<script>
    import Section from './Section.svelte';
    import Slider from '../UI/Slider/Slider.svelte';
    import Slide from '../UI/Slider/Slide.svelte';
    export let shopItems;
</script>

<Section name={'Часто заказывают'}>
    <Slider>
        {#each shopItems as shopItem}
            <Slide>
                <div class="recomendation-card">
                    <img class="recomendation-card__image" src={shopItem.image.url} alt="" />
                    <div class="recomendation-card__right">
                        <h3 class="recomendation-card__header">{shopItem.name}</h3>
                        <span class="recomendation-card__price">от {shopItem.price}p.</span>
                    </div>
                </div>
            </Slide>
        {/each}
    </Slider>
</Section>

<style>
    .recomendation-card {
        display: flex;
        padding: 16px;
        height: 112px;
        width: 260px;
        border-radius: 12px;
        box-shadow: rgba(6, 5, 50, 0.15) 0px 4px 22px -6px;
        transition: box-shadow 150ms ease-out 0s;
        cursor: pointer;
    }

    .recomendation-card__image {
        width: 80px;
    }
    .recomendation-card__right {
        padding-right: 8px;
        display: flex;
        flex-direction: column;
        justify-content: center;
    }

    .recomendation-card:hover {
        box-shadow: rgba(6, 5, 50, 0.15) 0px 0px 12px -4px;
    }

    .recomendation-card__header {
        display: -webkit-box;
        -webkit-line-clamp: 2;
        -webkit-box-orient: vertical;
        margin: 0;
        overflow: hidden;
        font-weight: 500;
        font-size: 16px;
        line-height: 20px;
    }

    .recomendation-card__price {
        font-weight: 500;
        line-height: 20px;
    }
</style>
