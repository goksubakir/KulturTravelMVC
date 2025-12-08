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
  
      // Avatar container oluştur
      const avatarContainer = document.createElement("div");
      avatarContainer.classList.add("avatar-container");
      avatarContainer.innerHTML = `
        <div class="avatar-box">
          <img src="data:image/svg+xml,%3Csvg width='64' height='64' viewBox='0 0 64 64' fill='none' xmlns='http://www.w3.org/2000/svg'%3E%3Ccircle cx='32' cy='32' r='32' fill='%2300b4d8'/%3E%3Ccircle cx='32' cy='26' r='12' fill='%23fff'/%3E%3Cpath d='M12 56c2.5-9.5 10.5-16 20-16s17.5 6.5 20 16' stroke='%23fff' stroke-width='6' stroke-linecap='round'/%3E%3C/svg%3E" alt="avatar" class="avatar-img">
          <span>${user.fullname}</span>
        </div>
        <div class="avatar-dropdown" id="avatarDropdown">
          <a href="/Reservation/MyReservations">Rezervasyonlarım</a>
          <a href="#" class="logout-link">Çıkış Yap</a>
        </div>
      `;

      // Navigasyona ekle
      nav.appendChild(avatarContainer);

      // Dropdown toggle
      const avatarBox = avatarContainer.querySelector(".avatar-box");
      const dropdown = avatarContainer.querySelector(".avatar-dropdown");
      
      avatarBox.addEventListener("click", (e) => {
        e.stopPropagation();
        e.preventDefault();
        const isOpen = dropdown.classList.contains("open");
        
        // Tüm dropdown'ları kapat
        document.querySelectorAll(".avatar-dropdown").forEach(dd => {
          dd.classList.remove("open");
        });
        
        // Bu dropdown'ı aç/kapat
        if (!isOpen) {
          dropdown.classList.add("open");
        }
      });
      
      // Dropdown içindeki linklere tıklama
      const dropdownLinks = avatarContainer.querySelectorAll(".avatar-dropdown a");
      dropdownLinks.forEach(link => {
        link.addEventListener("click", (e) => {
          if (!link.classList.contains("logout-link")) {
            dropdown.classList.remove("open");
          }
        });
      });
      
      // Dışarı tıklayınca dropdown'ı kapat
      document.addEventListener("click", (e) => {
        if (!avatarContainer.contains(e.target)) {
          dropdown.classList.remove("open");
        }
      });
      
      // Logout işlemi
      const logoutLink = avatarContainer.querySelector(".logout-link");
      if (logoutLink) {
        logoutLink.addEventListener("click", (e) => {
          e.preventDefault();
          e.stopPropagation();
          dropdown.classList.remove("open");
          localStorage.clear();
          setTimeout(() => {
            window.location.href = "/Auth/Login";
          }, 100);
        });
      }
    }
  });
  
  /* ========== BUTON ALERT ========== */
  function showAlert() {
    alert("Seyahat planlamanıza başlamak için giriş yapın veya kayıt olun!");
  }
  