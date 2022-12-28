class myFooter extends HTMLElement{
    connectedCallback(){
        this.innerHTML =  `
        
      
        `
    }
}

customElements.define('my-footer', myFooter);