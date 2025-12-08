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
  
      // Avatar kutusunu oluştur - INLINE ONCLICK KULLANARAK ESKİ EVENT LISTENER'LARI GEÇERSİZ KILIYORUZ
      const avatarContainer = document.createElement("div");
      avatarContainer.classList.add("avatar-container");
      const dropdownId = "avatarDropdown_" + Date.now();
      
      // Önce container'ı oluştur
      avatarContainer.innerHTML = `
        <div class="avatar-box" onclick="event.stopPropagation(); event.preventDefault(); event.stopImmediatePropagation(); var dd = document.getElementById('${dropdownId}'); if(dd) { var isOpen = dd.classList.contains('open'); document.querySelectorAll('.avatar-dropdown').forEach(function(d) { d.classList.remove('open'); }); if(isOpen) { dd.classList.remove('open'); } else { dd.classList.add('open'); } } return false;">
          <img src="data:image/svg+xml,%3Csvg width='64' height='64' viewBox='0 0 64 64' fill='none' xmlns='http://www.w3.org/2000/svg'%3E%3Ccircle cx='32' cy='32' r='32' fill='%2300b4d8'/%3E%3Ccircle cx='32' cy='26' r='12' fill='%23fff'/%3E%3Cpath d='M12 56c2.5-9.5 10.5-16 20-16s17.5 6.5 20 16' stroke='%23fff' stroke-width='6' stroke-linecap='round'/%3E%3C/svg%3E" alt="avatar" class="avatar-img">
          <span>${user.fullname}</span>
        </div>
        <div class="avatar-dropdown" id="${dropdownId}">
          <a href="/Reservation/MyReservations" onclick="document.getElementById('${dropdownId}').classList.remove('open');">Rezervasyonlarım</a>
          <a href="#" class="logout-link" onclick="event.stopPropagation(); event.preventDefault(); event.stopImmediatePropagation(); document.querySelectorAll('.avatar-dropdown').forEach(function(d) { d.classList.remove('open'); }); localStorage.clear(); setTimeout(function() { window.location.href = '/Auth/Login'; }, 100); return false;">Çıkış Yap</a>
        </div>
      `;

      // Navigasyona ekle
      nav.appendChild(avatarContainer);
  
      // Dropdown içindeki linklere tıklama (logout hariç)
      const dropdown = document.getElementById(dropdownId);
      const dropdownLinks = avatarContainer.querySelectorAll(".avatar-dropdown a:not(.logout-link)");
      dropdownLinks.forEach(function(link) {
        link.addEventListener("click", function() {
          dropdown.classList.remove("open");
        });
      });
      
      // Dışarı tıklayınca dropdown'ı kapat
      document.addEventListener("click", function(e) {
        if (!avatarContainer.contains(e.target)) {
          dropdown.classList.remove("open");
        }
      });
    }
  });
  
  /* ========== BUTON ALERT ========== */
  function showAlert() {
    alert("Seyahat planlamanıza başlamak için giriş yapın veya kayıt olun!");
  }

  /* ========== AVATAR DROPDOWN FUNCTIONS ========== */
  function toggleAvatarDropdown(event, dropdownId) {
    event.stopPropagation();
    event.preventDefault();
    event.stopImmediatePropagation();
    
    var dropdown = document.getElementById(dropdownId);
    if (!dropdown) return;
    
    // Tüm dropdown'ları kapat
    document.querySelectorAll(".avatar-dropdown").forEach(function(dd) {
      dd.classList.remove("open");
    });
    
    // Bu dropdown'ı aç/kapat
    if (dropdown.classList.contains("open")) {
      dropdown.classList.remove("open");
    } else {
      dropdown.classList.add("open");
    }
  }

  function handleLogout(event) {
    event.stopPropagation();
    event.preventDefault();
    event.stopImmediatePropagation();
    
    // Tüm dropdown'ları kapat
    document.querySelectorAll(".avatar-dropdown").forEach(function(dd) {
      dd.classList.remove("open");
    });
    
    localStorage.clear();
    setTimeout(function() {
      window.location.href = "/Auth/Login";
    }, 100);
  }
  