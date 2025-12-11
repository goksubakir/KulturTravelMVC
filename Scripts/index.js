/* ========== SLIDER ========== */
document.addEventListener("DOMContentLoaded", () => {
    const slides = document.querySelectorAll(".slider img");
    let currentSlide = 0;
  
    if (slides.length > 0) {
      slides[currentSlide].classList.add("active");
      setInterval(() => {
        slides[currentSlide].classList.remove("active");
        currentSlide = (currentSlide + 1) % slides.length;
        slides[currentSlide].classList.add("active");
      }, 4000);
    }
  });
  
  /* ========== BUTON ALERT ========== */
  function showAlert() {
    alert("Seyahat planlamanıza başlamak için giriş yapın veya kayıt olun!");
  }
  