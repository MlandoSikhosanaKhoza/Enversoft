var MakeAnOrder = {
    Cart: [],
    CartTable: undefined,
    ChangedSpinner() {
        var itemId = $(event.target).data("itemId");
        let ItemObject = MakeAnOrder.GetItemBy(itemId);
        ItemObject.quantity = parseInt(event.target.value);
        MakeAnOrder.CalculateTotal();
        MakeAnOrder.ProduceStorage();
    },
    Buy() {
        document.getElementById("btn-cms").disabled = false;
        document.getElementById("btn-gtm").disabled = false;
        var itemId = $(event.target).data("itemId");
        if (this.CheckIfItemExists(itemId)) {
            let ItemObject = MakeAnOrder.GetItemBy(itemId);
            ItemObject.increaseQuantity();
            $("#item-" + ItemObject.itemId).val(ItemObject.quantity);
            MakeAnOrder.CalculateTotal();
            MakeAnOrder.ProduceStorage();
        } else {
            let description = $(event.target).data("desc");
            let price = $(event.target).data("price");
            let ItemObject = new Item(itemId, description, 1, price);
            MakeAnOrder.Cart.push(ItemObject);
            console.log(ItemObject.getRow());
            MakeAnOrder.CartTable.row.add(ItemObject.getRow()).draw(false);
            MakeAnOrder.CalculateTotal();
            MakeAnOrder.ProduceStorage();
        }
    },
    CheckIfItemExists(itemId) {
        for (var i = 0; i < this.Cart.length; i++) {
            if (this.Cart[i].itemId == itemId) {
                return true;
            }
        }
        return false;
    },
    GetItemBy(itemId) {
        for (var i = 0; i < this.Cart.length; i++) {
            if (this.Cart[i].itemId == itemId) {
                return this.Cart[i];
            }
        }
        return undefined;
    },
    CalculateTotal() {
        var subtotal = 0;
        var total = 0;
        var vat = parseFloat($("#input-vat").val().replace(",", ".")) + 1;
        var quantity = 0;
        for (var i = 0; i < this.Cart.length; i++) {
            subtotal += this.Cart[i].quantity * this.Cart[i].price;
            quantity += this.Cart[i].quantity;
        }
        total = subtotal * vat;
        $("#sub-total").text("R " + subtotal.toFixed(2));
        $("#Subtotal").val(subtotal.toFixed(2).replace(".", ","));
        $("#GrandTotal").val(total.toFixed(2).replace(".", ","));
        $("#grand-total").text("R " + total.toFixed(2));
        $("#shop-quantity").text(quantity);
    },
    ProduceStorage() {
        var html = "";
        for (var i = 0; i < this.Cart.length; i++) {
            html += `<input type="hidden" name="ItemId" form="form-purchase" value="${this.Cart[i].itemId}"/>`;
            html += `<input type="hidden" name="Quantity" form="form-purchase" value="${this.Cart[i].quantity}"/>`;
            html += `<input type="hidden" name="Price" form="form-purchase" value="${this.Cart[i].getDecimalPrice()}"/>`;
        }
        $("#cart-storage").html(html);
    },
    Delete() {
        var itemId = $(event.target).data("itemId");
        for (let i = 0; i < this.Cart.length; i++) {
            if (this.Cart[i].itemId == itemId) {
                this.Cart.splice(i, 1);
            }
        }
        console.log(event.target.parentElement.parentElement);
        this.CartTable.row(event.target.parentElement.parentElement).remove().draw(false);
        if (this.Cart.length == 0) {
            document.getElementById("btn-cms").disabled = true;
            document.getElementById("btn-gtm").disabled = true;
        }
        this.CalculateTotal();
    }
};