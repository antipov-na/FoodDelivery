<script>
    import { onMount } from 'svelte';

    export let width;
    export let height;
    export let seam;
    export let selectedValue;

    let childrenCount;
    let sliderPos;

    onMount(() => {
        childrenCount = countRadioBtns();
        linkRadioBtns();
    });

    let countRadioBtns = () => {
        let slider = document.querySelector('.radio-slider');
        return slider.children.length - 1;
    };

    let linkRadioBtns = () => {
        let radioBtns = document.querySelectorAll('input');
        selectedValue = radioBtns[0].value;
        radioBtns.forEach((element, key) => {
            element.name = 'radio';
            element.addEventListener('click', () => {
                sliderPos = key;
                selectedValue = element.value;
            });
        });
    };
</script>

<div
    style="height: {height}px; 
           width: {width}px;"
    class="radio-slider"
>
    <slot />
    <div
        class="slider"
        style="width: {100 / childrenCount}%; 
               padding: {seam}px;
               transform: translate({(width / childrenCount) * sliderPos}px,-50%);"
    />
</div>

<style>
    .radio-slider {
        display: flex;
        position: relative;
        border-radius: 99999px;
        background-color: #90d459;
        align-items: center;
    }

    .slider {
        position: absolute;
        box-sizing: border-box;
        display: block;
        height: 100%;
        top: 50%;
        transform: translateY(-50%);
        transition: transform ease-in-out 200ms;
    }

    .slider::before {
        content: ' ';
        display: block;
        border-radius: 99999px;
        background-color: #fff;
        width: 100%;
        height: 100%;
    }
</style>
