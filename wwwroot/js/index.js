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
  
    /* ========== OTURUM KONTROLÜ ========== */
    const nav = document.querySelector("nav");
    const user = JSON.parse(localStorage.getItem("user"));
    const loggedIn = localStorage.getItem("loggedIn");
  
    // Eğer kullanıcı giriş yaptıysa
    if (loggedIn === "true" && user) {
      // Login linkini kaldır (MVC route'u ile)
      const loginLink = nav.querySelector('a[href*="Login"]');
      if (loginLink) loginLink.remove();
  
      // Avatar kutusunu oluştur
      const avatar = document.createElement("div");
      avatar.classList.add("avatar-box");
      avatar.innerHTML = `
        <img src="/images/7.png" alt="avatar" class="avatar-img" title="Çıkış yapmak için tıklayın">
        <span>${user.fullname}</span>
      `;
  
      // Navigasyona ekle
      nav.appendChild(avatar);
  
      // Logout işlemi
      avatar.addEventListener("click", () => {
        const confirmLogout = confirm("Çıkış yapmak istiyor musunuz?");
        if (confirmLogout) {
          localStorage.clear();
          alert("Çıkış yapıldı!");
          window.location.reload();
        }
      });
    }
  });
  
  /* ========== BUTON ALERT ========== */
  function showAlert() {
    alert("Seyahat planlamanıza başlamak için giriş yapın veya kayıt olun!");
  }
  