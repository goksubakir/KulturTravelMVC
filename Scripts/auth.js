/* ========== OTURUM KONTROLÜ (TÜM SAYFALAR İÇİN) ========== */
document.addEventListener("DOMContentLoaded", () => {
    const nav = document.querySelector("nav");
    const user = JSON.parse(localStorage.getItem("user"));
    const loggedIn = localStorage.getItem("loggedIn");
  
    // Eğer kullanıcı giriş yaptıysa
    if (loggedIn === "true" && user) {
      // Login linkini kaldır (MVC route'u ile)
      const loginLink = nav.querySelector('a[href*="Login"]');
      if (loginLink) loginLink.remove();

      // Avatar container oluştur (dropdown için)
      const avatarContainer = document.createElement("div");
      avatarContainer.classList.add("avatar-container");

      // Avatar kutusunu oluştur
      const avatar = document.createElement("div");
      avatar.classList.add("avatar-box");
      avatar.innerHTML = `
        <img src="/Content/images/7.png" alt="avatar" class="avatar-img">
        <span>${user.fullname}</span>
        <svg class="dropdown-arrow" width="12" height="12" viewBox="0 0 12 12" fill="currentColor">
          <path d="M2 4L6 8L10 4" stroke="currentColor" stroke-width="2" fill="none"/>
        </svg>
      `;

      // Dropdown menü oluştur
      const dropdownMenu = document.createElement("div");
      dropdownMenu.classList.add("avatar-dropdown");
      dropdownMenu.innerHTML = `
        <a href="/Reservation/MyReservations" class="dropdown-item">
          <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <path d="M19 21l-7-5-7 5V5a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2z"></path>
          </svg>
          Rezervasyonlarım
        </a>
        <div class="dropdown-divider"></div>
        <a href="#" class="dropdown-item logout-btn">
          <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <path d="M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4"></path>
            <polyline points="16 17 21 12 16 7"></polyline>
            <line x1="21" y1="12" x2="9" y2="12"></line>
          </svg>
          Çıkış Yap
        </a>
      `;

      avatarContainer.appendChild(avatar);
      avatarContainer.appendChild(dropdownMenu);
      nav.appendChild(avatarContainer);

      // Dropdown toggle işlemi
      avatar.addEventListener("click", (e) => {
        e.stopPropagation();
        avatarContainer.classList.toggle("active");
      });

      // Dışarıya tıklandığında dropdown'u kapat
      document.addEventListener("click", () => {
        avatarContainer.classList.remove("active");
      });

      // Logout işlemi (direkt çıkış yap)
      const logoutBtn = dropdownMenu.querySelector(".logout-btn");
      logoutBtn.addEventListener("click", (e) => {
        e.preventDefault();
        localStorage.clear();
        window.location.href = "/";
      });
    }
  });

