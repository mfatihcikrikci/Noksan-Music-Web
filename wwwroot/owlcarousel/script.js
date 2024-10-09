$('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    center: true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:5
        }
    }
})

document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function(e) {
        e.preventDefault();
        const targetID = this.getAttribute('href');
        document.querySelector(targetID).scrollIntoView({
            behavior: 'smooth'
        });
    });
});


function toggleMenu() {
    const navMenu = document.getElementById('nav-menu');
    navMenu.classList.toggle('show');
}

// document.querySelector('a[href="#menu"]').addEventListener('click', function(e) {
//     e.preventDefault(); // Varsayılan link davranışını engelle
//     document.querySelector('#menu').scrollIntoView({
//         behavior: 'smooth'
//     });
// });


