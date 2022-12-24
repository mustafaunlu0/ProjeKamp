class mySidebar extends HTMLElement{
    connectedCallback(){
        this.innerHTML =  `
        
        
        <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

        <!-- Sidebar - Brand -->
        <a class="sidebar-brand d-flex align-items-center justify-content-center" href="/Admin/Index">
            <div class="sidebar-brand-icon rotate-n-15">
                <i class="fas fa-hiking"></i>
            </div>
            <div class="sidebar-brand-text mx-3">Proje Kamp</div>
        </a>

        <!-- Divider -->
        <hr class="sidebar-divider my-0">

        <!-- Nav Item - Dashboard -->
        <li class="nav-item">
            <a class="nav-link" href="/Admin/Index">
                <i class="fas fa-fw fa-tachometer-alt"></i>
                <span>Dashboard</span>
            </a>
        </li>

        <!-- Divider -->
        <hr class="sidebar-divider">

        <!-- Heading -->
        <div class="sidebar-heading">
            Kayıtlılar
        </div>

        <!-- Nav Item - Kullanıcılar -->
        <li class="nav-item">
            <a class="nav-link" href="/Admin/ListUser">
                <i class="fas fa-fw fa-users"></i>
                <span>Kullanıcılar</span></a>
        </li>

        <!-- Nav Item - Adminler -->
        <li class="nav-item">
            <a class="nav-link" href="/Admin/ListAdmin">
                <i class="fas fa-fw fa-user"></i>
                <span>Adminler</span></a>
        </li>

        <!-- Divider -->
        <hr class="sidebar-divider">

        <div class="sidebar-heading">
            Kamplar
        </div>


        <!-- Nav Item - Kamp Oluştur -->
        <li class="nav-item">
            <a class="nav-link" href="/Admin/CreateCamp">
                <i class="fas fa-fw fa-plus"></i>
                <span>Kamp Oluştur</span></a>
        </li>

        <!-- Nav Item - Kamplar -->
        <li class="nav-item">
            <a class="nav-link" href="/Admin/ListCamp">
                <i class="fas fa-fw fa-campground"></i>
                <span>Kamplar</span></a>
        </li>

        <!-- Divider -->
        <hr class="sidebar-divider d-none d-md-block">

        <!-- Sidebar Toggler (Sidebar) -->
        <div class="text-center d-none d-md-inline">
            <button class="rounded-circle border-0" id="sidebarToggle"></button>
        </div>

    </ul>
        
        `
    }
}

customElements.define('my-sidebar', mySidebar);