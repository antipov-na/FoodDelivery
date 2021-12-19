<script>
    import { onMount } from 'svelte';
    import Section from './Section.svelte';
    import { Swiper, SwiperSlide } from 'swiper/svelte';
    import SwiperCore, { Navigation } from 'swiper';
    import 'swiper/css';
    import 'swiper/css/navigation';

    let swiper;

    onMount(() => {
        console.log(swiper);
    });
    SwiperCore.use([Navigation]);
</script>

<Section name={'Часто заказывают'}>
    <Swiper
        navigation
        style="padding: 20px calc((100vw - 100%) / 2); margin: 0 calc((100vw - 100%) / -2 + 4px)"
        params={{}}
        bind:this={swiper}
        spaceBetween={24}
        slidesPerView={4.5}
        on:slideChange={() => console.log('slide change')}
        on:swiper={(e) => console.log(e.detail[0])}
    >
        {#each Array(7) as _, i}
            <SwiperSlide>
                <div class="recomendation-card">
                    <picture class="recomendation-card__image">
                        <source
                            srcset="https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_138x138.jpeg 138w,https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_146x146.jpeg 146w,https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_183x183.jpeg 183w,https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_233x233.jpeg 233w,https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_292x292.jpeg 292w,https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_366x366.jpeg 366w,https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_584x584.jpeg 584w,https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_760x760.jpeg 760w,https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_1875x1875.jpeg 1875w"
                            sizes="146px"
                        />
                        <img
                            alt="Ветчина и грибы"
                            title="Ветчина и грибы"
                            src="https://cdn.dodopizza.net/static/Img/Products/b1ffa66f2ebb4e959122e54eaa071109_138x138.jpeg"
                        />
                    </picture>
                    <h3 class="recomendation-card__header">Ветчина и грибы</h3>
                    <span class="recomendation-card__price">от 240 p.</span>
                </div>
            </SwiperSlide>
        {/each}
    </Swiper>
</Section>

<style>
    .recomendation-card {
        display: flex;
        flex-wrap: wrap;
        flex-direction: column;
        height: 112px;
        box-sizing: border-box;
        padding: 16px;
        border-radius: 12px;
        transition: box-shadow 150ms ease-out 0s;
        box-shadow: rgba(6, 5, 50, 0.15) 0px 4px 22px -6px;
        cursor: pointer;
    }

    .recomendation-card:hover {
        box-shadow: rgba(6, 5, 50, 0.15) 0px 0px 12px -4px;
    }

    .recomendation-card__header {
        font-weight: 500;
        font-size: 16px;
        line-height: 20px;
    }

    .recomendation-card__price {
        font-weight: 500;
    }

    img {
        width: 80px;
    }
</style>
