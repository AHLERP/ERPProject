// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function flipCard(cardIndex) {
    var cards = document.querySelectorAll('.card');
    cards[cardIndex].style.transform = cards[cardIndex].style.transform === 'rotateY(180deg)' ? 'rotateY(0deg)' : 'rotateY(180deg)';
}