window.initializeBootstrapComponents = function () {
    if (typeof bootstrap !== 'undefined') {
        // Initialize dropdowns
        var dropdownElementList = [].slice.call(document.querySelectorAll('.dropdown-toggle'));
        dropdownElementList.forEach(function (element) {
            new bootstrap.Dropdown(element);
        });

        // Initialize collapsible navbar
        var navbarToggler = document.querySelector('.navbar-toggler');
        if (navbarToggler) {
            navbarToggler.addEventListener('click', function () {
                var target = document.querySelector(navbarToggler.getAttribute('data-bs-target'));
                if (target) {
                    target.classList.toggle('show');
                }
            });
        }
    } else {
        console.error('Bootstrap is not loaded!');
    }
}