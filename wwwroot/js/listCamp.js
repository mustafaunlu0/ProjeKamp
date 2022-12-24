gsap.registerPlugin(Physics2DPlugin);

document.querySelectorAll('.button').forEach(button => {

    button.addEventListener('click', e => {
        button.classList.toggle('liked');
        if (button.classList.contains('liked')) {
            setTimeout(() => {
                particles(button.querySelector('.emitter'), 100, 0, 0, 360, button.offsetWidth);
            }, 160);
        }
    })

});

function particles(parent, quantity, y, minAngle, maxAngle, width) {
    let colors = [
        '#FFFF04',
        '#EA4C89',
        '#892AB8',
        '#4AF2FD',
        '#275EFE'
    ];
    for (let i = quantity - 1; i >= 0; i--) {
        let angle = gsap.utils.random(minAngle, maxAngle),
            velocity = gsap.utils.random(70, 100),
            dot = document.createElement('div');
        dot.style.setProperty('--b', colors[Math.floor(gsap.utils.random(0, 5))]);
        parent.appendChild(dot);
        gsap.set(dot, {
            x: gsap.utils.random(width * -.5, width * .5),
            y: y,
            scale: gsap.utils.random(.4, .8)
        });
        gsap.timeline({
            onComplete() {
                dot.remove();
            }
        }).to(dot, {
            duration: 1.7,
            rotationX: `-=${gsap.utils.random(180, 720)}`,
            rotationZ: `+=${gsap.utils.random(180, 720)}`,
            physics2D: {
                angle: angle,
                velocity: velocity
            }
        }).to(dot, {
            duration: .7,
            opacity: 0
        }, 1);
    }
}
function a() {
alert("listCamp")
}
