document.addEventListener("DOMContentLoaded", function (event) {

    const showNavbar = (toggleId, navId, bodyId, headerId, infocardId, pageID ) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId)
            infocardpd = document.getElementById(infocardId)
            pagepd = document.getElementById(pageID)

        // Validate that all variables exist
        if (toggle && nav && bodypd && headerpd) {
            toggle.addEventListener('click', () => {
                // show navbar
                nav.classList.toggle('enable')
                // change icon
                toggle.classList.toggle('bx-x')
                // add padding to body
                bodypd.classList.toggle('body-pd')
                // add padding to header
                headerpd.classList.toggle('body-pd')


                if (infocardpd.classList.contains("not-show")) {
                    infocardpd.classList.remove("not-show");
                }
                else {
                    infocardpd.classList.add("not-show");
                }

                if (pagepd.classList.contains("not-show")) {
                    pagepd.classList.remove("not-show");
                }
                else {
                    pagepd.classList.add("not-show");
                }


            })
        }
    }

    showNavbar('header-toggle', 'nav-bar', 'body-pd', 'header', 'info-card', 'page-logo')

    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link')

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'))
            this.classList.add('active')
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink))

    // Your code to run since DOM is loaded and ready
});