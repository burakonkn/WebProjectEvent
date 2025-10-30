document.addEventListener('DOMContentLoaded', () => {
    
    const menuButton = document.getElementById('mobile-menu-btn');
    const sidebar = document.getElementById('admin-sidebar');

    if (menuButton && sidebar) {
        menuButton.addEventListener('click', () => {
            sidebar.classList.toggle('open');
        });
    }

});