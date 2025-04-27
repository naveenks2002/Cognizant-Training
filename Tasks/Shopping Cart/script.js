$(document).ready(function() {
    let products = [
        { name: "Laptop", price: 700 },
        { name: "Smartphone", price: 400 },
        { name: "Headphones", price: 50 },
        { name: "Tablet", price: 300 },
        { name: "Gaming Console", price: 500 }
    ];

    let cart = [];

    function displayProducts() {
        $("#product-list").empty();
        products.forEach((product, index) => {
            $("#product-list").append(`
                <div class="col-md-4 mb-3">
                    <div class="card">
                        <div class="card-body text-center">
                            <h5>${product.name}</h5>
                            <p>Price: $${product.price}</p>
                            <button class="btn btn-success add-to-cart" data-index="${index}">Add to Cart</button>
                        </div>
                    </div>
                </div>
            `);
        });
    }

    $(document).on("click", ".add-to-cart", function() {
        let index = $(this).data("index");
        let selectedItem = products[index];

        let existingItem = cart.find(item => item.name === selectedItem.name);
        if (existingItem) {
            existingItem.quantity++;
        } else {
            cart.push({ ...selectedItem, quantity: 1 });
        }

        updateCart();
    });

    function updateCart() {
        $("#cart-items").empty();
        let total = 0;
        cart.forEach((item, index) => {
            total += item.price * item.quantity;
            $("#cart-items").append(`
                <div class="list-group-item d-flex justify-content-between">
                    <span>${item.name} - $${item.price} x ${item.quantity}</span>
                    <button class="btn btn-danger btn-sm remove-item" data-index="${index}">Remove</button>
                </div>
            `);
        });

        $("#total-price").text(total);

        $(".remove-item").click(function() {
            let index = $(this).data("index");
            cart.splice(index, 1);
            updateCart();
        });
    }

    displayProducts();
});
