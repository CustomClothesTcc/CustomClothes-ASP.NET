products = [
    { name: "Notebook Dell", url: "http://localhost:5174/Produto/Produto" },
    { name: "iPhone 14", url: "https://www.Apple.com/iphone-14" },
    { name: "Smart TV Samsung", url: "https://www.Samsung.com/smart-tv-samsung" },
    { name: "Fone de Ouvido Sony", url: "https://www.G1.com.br/" }
];

let selectedUrl = '';

function autocomplete(inputElement, items) {
    let currentFocus;

    inputElement.addEventListener("input", function () {
        let listContainer, listItem, i, val = this.value;

        closeAllLists();
        if (!val) return false;
        currentFocus = -1;

        listContainer = document.createElement("div");
        listContainer.setAttribute("id", this.id + "-autocomplete-list");
        listContainer.setAttribute("class", "autocomplete-items");
        this.parentNode.appendChild(listContainer);

        for (i = 0; i < items.length; i++) {
            if (items[i].name.substr(0, val.length).toLowerCase() === val.toLowerCase()) {
                listItem = document.createElement("div");
                listItem.innerHTML = "<strong>" + items[i].name.substr(0, val.length) + "</strong>";
                listItem.innerHTML += items[i].name.substr(val.length);
                listItem.setAttribute("class", "autocomplete-item");
                listItem.addEventListener("click", function () {
                    inputElement.value = this.innerText;
                    selectedUrl = items.find(item => item.name === this.innerText).url;
                    closeAllLists();
                });
                listContainer.appendChild(listItem);
            }
        }
    });

    inputElement.addEventListener("keydown", function (e) {
        let x = document.getElementById(this.id + "-autocomplete-list");
        if (x) x = x.getElementsByTagName("div");
        if (e.keyCode == 40) {
            currentFocus++;
            addActive(x);
        } else if (e.keyCode == 38) {
            currentFocus--;
            addActive(x);
        } else if (e.keyCode == 13) {
            e.preventDefault();
            if (currentFocus > -1) {
                if (x) x[currentFocus].click();
            }
        }
    });

    function addActive(x) {
        if (!x) return false;
        removeActive(x);
        if (currentFocus >= x.length) currentFocus = 0;
        if (currentFocus < 0) currentFocus = (x.length - 1);
        x[currentFocus].classList.add("autocomplete-active");
    }

    function removeActive(x) {
        for (let i = 0; i < x.length; i++) {
            x[i].classList.remove("autocomplete-active");
        }
    }

    function closeAllLists(elmnt) {
        let x = document.getElementsByClassName("autocomplete-items");
        for (let i = 0; i < x.length; i++) {
            if (elmnt != x[i] && elmnt != inputElement) {
                x[i].parentNode.removeChild(x[i]);
            }
        }
    }

    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });
}

function redirectToLink() {
    if (selectedUrl) {
        window.location.href = selectedUrl;
    } else {
        alert("Por favor, selecione um produto válido.");
    }
}

document.getElementById("search-button").addEventListener("click", redirectToLink);

autocomplete(document.getElementById("search-bar"), products);

