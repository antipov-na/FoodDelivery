<script>
    import { onMount } from 'svelte';
    export let offset = 0;

    let slider;
    let startX;
    let offsetOld;

    let slidesCords;
    let currentSlide = 0;

    onMount(() => {
        slidesCords = getSlidesCords();
    });

    let handleMove = (e) => {
        let newOffset = offsetOld - (e.clientX - startX);
        moveSlider(newOffset);
    };

    let handleRelease = () => {
        document.body.removeEventListener('mousemove', handleMove);
        enableTransition();
        moveSliderToNearestSlide();
    };

    let hendleGrab = (e) => {
        e.preventDefault();
        disableTransition();

        document.body.addEventListener('mousemove', handleMove);
        startX = e.clientX;
        const currentOffset = window.getComputedStyle(slider).transform.split(', ')[4];
        offsetOld = -currentOffset;
    };

    let clampOffset = (offset) => {
        let width = slider.scrollWidth;
        return Math.min(Math.max(offset, 0), width - slider.getBoundingClientRect().width);
    };

    let moveSlider = (offsetToMove) => {
        offset = clampOffset(offsetToMove);
        slider.style.transform = `translateX(-${offset}px)`;
    };

    let moveSliderToNearestSlide = () => {
        let clampedOffset = clampOffset(offset);
        let absClampedOffset = Math.abs(clampedOffset);

        if (
            slider.scrollWidth - (absClampedOffset + slider.getBoundingClientRect().width) <
            slider.children[slider.children.length - 1].getBoundingClientRect().width / 2
        ) {
            absClampedOffset = slider.scrollWidth - slider.getBoundingClientRect().width;
            currentSlide = slidesCords.length - 1;
        } else {
            absClampedOffset = slidesCords.reduce(function (prev, curr) {
                return Math.abs(curr - absClampedOffset) < Math.abs(prev - absClampedOffset) ? curr : prev;
            });
            currentSlide = slidesCords.indexOf(absClampedOffset);
        }
        moveSlider(absClampedOffset);
    };

    let nextSlide = () => {
        if (currentSlide < slidesCords.length - 1) {
            currentSlide++;
        }
        enableTransition();
        moveSlider(slidesCords[currentSlide]);
    };

    let previousSlide = () => {
        if (currentSlide > 0) {
            currentSlide--;
        }
        enableTransition();
        moveSlider(slidesCords[currentSlide]);
    };

    let enableTransition = () => {
        slider.style.transition = 'transform 1s ease';
    };

    let disableTransition = () => {
        slider.style.transition = '';
    };

    let getSlidesCords = () => {
        let children = slider.children;
        let result = [0];

        //fix 0-1 lenth array
        for (let i = 1; i < children.length - 1; i++) {
            let tempX = result[i - 1] + children[i].getBoundingClientRect().width + 24;
            if (tempX > slider.scrollWidth - slider.getBoundingClientRect().width) {
                result[i] = slider.scrollWidth;
                break;
            }
            result[i] = tempX;
        }

        return result;
    };
</script>

<svelte:body on:mouseup={handleRelease} />
<div class="slider" on:mousedown={hendleGrab} style="position: relative;">
    <div bind:this={slider} class="inner-slider" style="transform: translateX(0);">
        <slot />
    </div>

    <div class="left-btn-click-handler" on:click={previousSlide}><slot name="left-btn" /></div>
    <div class="right-btn-click-handler" on:click={nextSlide}><slot name="right-btn" /></div>
</div>

<style>
    .inner-slider {
        display: flex;
        gap: 24px;
        padding: 15px 0;
    }

    .slider .left-btn-click-handler > :global(*),
    .slider .right-btn-click-handler > :global(*) {
        position: absolute;
        top: 50%;
        transform: translateY(-50%);
    }

    .slider .left-btn-click-handler > :global(*) {
        left: 0;
    }

    .slider .right-btn-click-handler > :global(*) {
        right: 0;
    }
</style>
