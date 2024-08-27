document.addEventListener('DOMContentLoaded', function () {
    var currentPath = window.location.pathname; // Mevcut sayfanın yolunu al

    // Menü öğelerini seç
    var navLinks = document.querySelectorAll('.nav-treeview .nav-link');

    navLinks.forEach(function (link) {
        var href = link.getAttribute('href');

        if (href && currentPath.startsWith(href)) {
            // Aktif olan menü öğesine 'active' sınıfı ekle
            link.classList.add('active');

            // Ana menü öğesini açık tut
            var parentNavItem = link.closest('.nav-item.has-treeview');
            if (parentNavItem) {
                parentNavItem.classList.add('menu-open'); // Menü açık durumda
                var navLink = parentNavItem.querySelector('.nav-link');
                if (navLink) {
                    navLink.classList.add('active'); // Ana menü öğesine de 'active' sınıfı ekle
                }
            }
        }
    });
});