<script>
    import { shopItems, itemTypes } from '../../stores/apiDataProvider.js';
    import ShopCategoryAdmin from '../../components/admin/ShopCategoryAdmin.svelte';
    import Modal from '../../components/Modal.svelte';
    function addItemHandler(e) {
        let formData = new FormData(e.target);
        shopItems.addItem(formData);
    }
    function addItemTypeHandler(e) {
        let formData = new FormData(e.target);
        itemTypes.addItemType(formData);
    }
</script>

<div class="container">
    <Modal>
        <div slot="trigger">Добавить предмет</div>
        <div slot="header"><h2 style=" margin: 0 0 20px 0;">Добавить предмет</h2></div>
        <div slot="content">
            <form enctype="multipart/form-data" on:submit|preventDefault={(e) => addItemHandler(e)}>
                <label for="name"> Название: </label>
                <input required type="text" id="name" name="dto.Name" />

                <label for="description"> Описание: </label>
                <textarea required name="dto.Description" id="description" cols="30" rows="5" />

                <label for="type"> Тип: </label>
                <select required name="dto.TypeId" id="type">
                    {#each $itemTypes as type}
                        <option value={type.id}>{type.name}</option>
                    {/each}
                </select>

                <label for="price"> Цена: </label>
                <input required type="number" step=".01" id="price" name="dto.Price" />

                <label for="image"> Изображение: </label>
                <input required type="file" name="image" id="image" />
                <label for="" />
                <input type="submit" value="Принять" />
            </form>
        </div>
    </Modal>
    <Modal>
        <div slot="trigger">Добавить категорию</div>
        <div slot="header"><h2 style=" margin: 0 0 20px 0;">Добавить категорию</h2></div>
        <div slot="content">
            <form enctype="multipart/form-data" on:submit|preventDefault={(e) => addItemTypeHandler(e)}>
                <label for="name">Название:</label>
                <input type="text" name="Name" id="name" />
                <label for="" />
                <input type="submit" value="Готово" />
            </form>
        </div>
    </Modal>

    {#each $itemTypes as type}
        <ShopCategoryAdmin {type} items={$shopItems} />
    {/each}
</div>

<style>
</style>
