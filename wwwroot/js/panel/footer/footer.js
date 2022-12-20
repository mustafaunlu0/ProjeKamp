class myFooter extends HTMLElement{
    connectedCallback(){
        this.innerHTML =  `
        
        <footer class="sticky-footer bg-white">
        <div class="container my-auto">
          <div class="copyright text-center my-auto">
            <span>Copyright &copy; Proje Kamp 2022</span>
          </div>
        </div>
      </footer>
        `
    }
}

customElements.define('my-footer', myFooter);