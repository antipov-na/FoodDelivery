<script>
    import Section from './Section.svelte';
</script>

<Section name={'Доставка и оплата'}>
    <div class="section-container">
        <div class="section-part">
            <h3 class="section-part__header">60 минут или пицца бесплатно</h3>
            <p class="section-part__paragraph">
                Если мы не успеем доставить продукты в течение 60 минут, кроме соусов и продуктов из раздела «Другие
                товары», курьер подарит вам сертификат или промокод на большую пиццу 35 см на традиционном тесте.
            </p>
        </div>
        <div class="section-part">
            <h3 class="section-part__header">Додо пицца — сеть пиццерий № 1 в России</h3>
            <p class="section-part__paragraph">
                по доставке пиццы по данным из отчета Euromonitor International на май 2017 года.
            </p>
            <p class="section-part__paragraph">Все цены в меню указаны без учета скидок.</p>
        </div>
        <div class="section-part">
            <h3 class="section-part__header">495 ₽</h3>
            <p class="section-part__paragraph">
                Минимальная сумма доставки без учета товаров из категории «Другие товары»
            </p>
            <h3 class="section-part__header">7 000 ₽</h3>
            <p class="section-part__paragraph">Максимальная сумма при оплате наличными</p>
            <p class="section-part__paragraph">Изображения продуктов могут отличаться от продуктов в заказе.</p>
        </div>
        <div class="section-part">
            <h3 class="section-part__header">Зона доставки ограничена</h3>
            <a
                class="map-link"
                href="https://yandex.ru/maps/2/saint-petersburg/?um=constructor%3AcZ8jlmZLjlCrVyoIVmAWS8eYY731JPbs&amp%3Bsource=constructorLink&mode=usermaps&ll=30.346936%2C59.928482&z=14"
            >
                <img src="https://cdn.dodopizza.net/site-static/dist/afdce5bbb5d38204b6c6.jpg" alt="" />
                <span class="map-link__text">Зона доставки</span>
            </a>
        </div>
    </div>
</Section>

<style>
    .section-container {
        display: flex;
        justify-content: space-between;
        gap: 50px;
        padding-bottom: 20px;
    }
    .section-part {
        flex: 1 1 0px;
    }

    .map-link {
        position: relative;
        display: block;
        overflow: hidden;
        border-radius: 10px;
    }

    .map-link__text {
        font-size: 20px;
        font-weight: 500;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        position: absolute;
        white-space: nowrap;
    }

    img {
        width: 100%;
    }

    img:hover {
        transform: scale(1.2) translate(-15px, -15px);
        filter: saturate(2);
        transition: transform 5s ease-out 0s;
    }

    .section-part__header {
        margin: 0px 0px 5px;
        font-weight: 500;
        font-size: 18px;
        color: rgb(255, 105, 0);
        text-transform: uppercase;
    }
    .section-part__paragraph {
        font-weight: 500;
        font-size: 16px;
        margin: 0;
        line-height: 150%;
        margin: 0px 0px 20px;
    }
</style>
