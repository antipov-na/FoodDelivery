<script>
    let isOpen = false;
    function open() {
        isOpen = true;
    }
    function close() {
        isOpen = false;
    }

    function keydown(e) {
        e.stopPropagation();
        if (e.key === 'Escape') {
            close();
        }
    }
</script>

<button on:click={open}><slot name="trigger" /></button>

{#if isOpen}
    <div class="dialog-wrapper" on:keydown={keydown} tabindex={0}>
        <div class="dialog">
            <button class="close-btn" on:click={() => close()}>
                <span class="visually-hidden">Закрыть диалоговое окно</span>
            </button>
            <slot name="header" />

            <div>
                <slot name="content" />
            </div>

            <slot name="footer" />
        </div>
    </div>
{/if}

<style>
    .visually-hidden {
        position: absolute !important;
        height: 1px;
        width: 1px;
        overflow: hidden;
        clip: rect(1px 1px 1px 1px);
        clip: rect(1px, 1px, 1px, 1px);
        white-space: nowrap;
    }

    .close-btn {
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

    .dialog {
        position: relative;
        padding: 1rem;
        border-radius: 1rem;
        background-color: white;
        display: block;
        position: absolute;
        top: 50%;
        left: 50%;
        -moz-transform: translateX(-50%) translateY(-50%);
        -webkit-transform: translateX(-50%) translateY(-50%);
        transform: translateX(-50%) translateY(-50%);
    }

    .dialog-wrapper {
        background: rgba(0, 0, 0, 0.8);
        position: fixed;
        top: 0;
        left: 0;
        bottom: 0;
        right: 0;
    }
</style>
