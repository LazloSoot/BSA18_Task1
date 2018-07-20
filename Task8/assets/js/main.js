window.onload = function() {
  // main-menu
  var menu = document.querySelector(".main-nav");
  var toggleMenuBtn = document.querySelector(".main-nav__toggle")
  if(menu.classList.contains("main-nav--nojs")){
    menu.classList.remove("main-nav--nojs");
  }
  toggleMenu();
  
  toggleMenuBtn.addEventListener("click", function(){
   // alert("pressed");
    toggleMenu();
  });
  
  function toggleMenu() {
    menu.classList.toggle("main-nav--opened");
    menu.classList.toggle("main-nav--closed");
  }
    
    // for search input
    
    $(".search__icon").click(function(){
    $(".search, .search__input").toggleClass("active");
    $("input[type='text']").focus();
  });
}