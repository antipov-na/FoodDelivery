<script>
    let buttonProps = {
        class: $$restProps.class,
        disabled: $$restProps.disabled
    };
</script>

<button on:click on:focus on:mouseover on:mouseenter on:mouseleave {...buttonProps}>
    <slot />
</button>

<style>
    button {
        margin: 0;

        outline-offset: -2px;

        font-weight: 500;
        text-decoration: none;
        text-align: center;

        cursor: pointer;
        border: medium none;
        border-radius: 9999px;

        transition-property: background-color, color, outline;
        transition-duration: 200ms;
        transition-timing-function: ease-out;
    }

    button:disabled {
        cursor: default;
    }

    .small {
        padding: 8px 16px;
        height: 32px;
        font-size: 14px;
        line-height: 16px;
    }

    .medium {
        padding: 8px 20px;
        font-size: 16px;
        line-height: 24px;
    }

    .primary {
        outline: #ff6900;
        background-color: #ff6900;
        color: #ffffff;
    }

    .primary:hover {
        background-color: #e86100;
        color: #ffffff;
    }

    .secondary {
        outline: #fff0e6;
        background-color: #fff0e6;
        color: #d15700;
    }

    .secondary:hover {
        background-color: #ffd2b3;
        color: #d15700;
    }

    .tertiary {
        outline: #f3f3f7;
        background-color: #f3f3f7;
        color: #5c6370;
    }

    .tertiary:hover {
        color: #000000;
    }

    .primary:focus,
    .secondary:focus {
        outline: #0096ff solid 2px;
    }
</style>
