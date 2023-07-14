function Item(itemId, name, quantity, price) {
    var _THIS = this;
    this.name = name;
    this.itemId = itemId;
    this.quantity = quantity;
    this.price = parseFloat((price + "").replace(",", "."));
    this.increaseQuantity = function () {
        _THIS.quantity++;
    };
    this.decreaseQuantity = function () {
        _THIS.quantity--;
    };
    this.getDecimalPrice = function () {
        return `${_THIS.price}`.replace(".", ",");
    };
    this.getRow = function () {
        return [name, `<input type="number" class="form-control dt-spinner" onchange="MakeAnOrder.ChangedSpinner()" min="1" data-item-id="${_THIS.itemId}" id="item-${_THIS.itemId}" value="${_THIS.quantity}"/>`, price, `<button data-item-id="${_THIS.itemId}" onclick="MakeAnOrder.Delete()" class="btn btn-primary">Delete</button>`];
    };
}