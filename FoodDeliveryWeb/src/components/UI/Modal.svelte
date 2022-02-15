<script>
    export let isVisible;
</script>

<div
    class="modal-container"
    class:visible={isVisible}
    on:click={() => (isVisible = false)}
    on:keypress={(e) => {
        if (e.key == 'Escape') isVisible = false;
    }}
>
    <div class="modal" on:click|stopPropagation>
        <div class="close" on:click={() => (isVisible = false)}>
            <svg width="25" height="25" viewBox="0 0 25 25" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path
                    fill-rule="evenodd"
                    clip-rule="evenodd"
                    d="M9.84606 12.4986L0.552631 3.20519C-0.1806 2.47196 -0.1806 1.28315 0.552631 0.549923C1.28586 -0.183308 2.47466 -0.183308 3.20789 0.549923L12.5013 9.84335L21.792 0.552631C22.5253 -0.1806 23.7141 -0.1806 24.4473 0.552631C25.1805 1.28586 25.1805 2.47466 24.4473 3.20789L15.1566 12.4986L24.45 21.792C25.1832 22.5253 25.1832 23.7141 24.45 24.4473C23.7168 25.1805 22.528 25.1805 21.7947 24.4473L12.5013 15.1539L3.20519 24.45C2.47196 25.1832 1.28315 25.1832 0.549923 24.45C-0.183308 23.7168 -0.183308 22.528 0.549923 21.7947L9.84606 12.4986Z"
                    fill="white"
                />
            </svg>
        </div>
        <slot />
    </div>
</div>

<style>
    .modal-container {
        z-index: 10000;

        display: flex;
        position: fixed;

        top: 0;
        right: 0;
        left: 0;
        bottom: 0;
        background: #000000cc;

        visibility: hidden;
        opacity: 0;

        pointer-events: none;

        transition: opacity 200ms ease-out;
    }

    .visible {
        visibility: visible;
        opacity: 1;

        pointer-events: visible;
    }

    .modal {
        position: relative;

        margin: auto;
        padding: 32px;

        max-width: 60%;
        max-height: 80%;
        min-width: 200px;
        min-height: 200px;

        background-color: white;
        overscroll-behavior: contain;

        border-radius: 20px;

        transform: scale(0.8);

        transition: transform 200ms ease-out;
    }

    .visible .modal {
        transform: scale(1);
    }

    .close {
        position: absolute;
        right: -45px;
        top: 15px;

        cursor: pointer;

        transform: scale(1);

        transition: transform 200ms ease-in-out;
    }

    .close:hover {
        transform: scale(1.1);
    }
</style>
