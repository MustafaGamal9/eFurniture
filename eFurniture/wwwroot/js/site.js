
function toggleMenu() {
    const toggle = document.getElementById('toggle-btn');
    const menu = document.getElementById('menu');
    // Check if menu is currently open by checking if inline styles are present
    if (menu.style.display === 'flex') {
        // Close the menu by removing all inline styles
        menu.removeAttribute('style');
        toggle.removeAttribute('style');
    } else {
        // Open the menu by applying necessary inline styles
        menu.style.display = 'flex';
        menu.style.flexDirection = 'column';
        menu.style.justifyContent = 'center';
        menu.style.alignItems = 'center';
        menu.style.position = 'fixed';
        menu.style.top = '4rem';
        menu.style.left = '5rem';
        menu.style.width = 'auto';
        menu.style.height = 'auto';
        menu.style.backgroundColor = '#5C3317';
        // menuItem.style.color = '#D99F54';
        menu.style.zIndex = '1000';
        menu.style.padding = '0.5rem';
        menu.style.borderRadius = '5px';
        menu.style.boxShadow = '0 0 10px rgba(0, 0, 0, 0.5)';
        menu.style.transform = 'translateX(-50%)';

        // Hide the toggle button
        toggle.style.display = 'none';

        // Add event listeners to close menu on interaction
        document.addEventListener('click', closeMenu);
        window.addEventListener('scroll', closeMenu);
        window.addEventListener('resize', returnMenuToOriginalState);
    }
}

function closeMenu() {
    const menu = document.getElementById('menu');
    const toggle = document.getElementById('toggle-btn');

    // Remove all inline styles to revert to CSS control
    menu.removeAttribute('style');
    toggle.removeAttribute('style');

    // Cleanup event listeners
    document.removeEventListener('click', closeMenu);
    window.removeEventListener('scroll', closeMenu);
    window.removeEventListener('resize', returnMenuToOriginalState);
}

function returnMenuToOriginalState() {
    const menu = document.getElementById('menu');
    // Check if screen is desktop size and reset styles
    if (window.innerWidth >= 768) {
        menu.removeAttribute('style');
    }
}

// Initialize toggle button event listener
document.getElementById('toggle-btn').addEventListener('click', function (e) {
    e.stopPropagation(); // Prevent immediate close when clicking toggle
    toggleMenu();
});