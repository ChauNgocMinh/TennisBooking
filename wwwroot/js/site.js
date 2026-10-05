// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const translations = {
    vi: {
        "nav.home": "Trang chủ", "nav.booking": "Đặt sân", "nav.coaches": "Huấn luyện viên", "nav.news": "Tin tức",
        "nav.tournament": "Giải đấu", "nav.training": "Sân tập", "nav.promotion": "Khuyến mãi",
        "nav.about": "Về chúng tôi", "language.vietnamese": "VN", "language.english": "ENG",
        "page.title": "TennisBooking", "footer.privacy": "Chính sách bảo mật", "home.title": "CHÀO MỪNG ĐẾN HỌC VIỆN ACE TENNIS",
        "home.subtitle": "Huấn luyện tennis chuyên nghiệp tại TP.HCM", "home.customers": "Khách hàng đã tin tưởng",
        "home.bookNow": "Đặt lịch ngay", "schedule.eyebrow": "ĐẶT LỊCH LINH HOẠT",
        "schedule.title": "Chọn khung giờ học", "schedule.description": "Chọn giờ bắt đầu và giờ kết thúc để xem khoảng thời gian bạn muốn đăng ký.",
        "schedule.date": "Ngày học", "schedule.classType": "Loại lớp", "schedule.private": "Lớp cá nhân",
        "schedule.group": "Lớp nhóm", "schedule.kids": "Lớp trẻ em", "schedule.selected": "Khung giờ đã chọn",
        "schedule.none": "Chưa chọn giờ", "schedule.start": "Chọn giờ bắt đầu", "schedule.end": "Chọn giờ kết thúc",
        "schedule.note": "Giờ hoạt động: 08:00–22:00 · Mỗi lần chọn cách nhau 1 giờ", "nav.toggle": "Mở menu",
        "footer.tagline": "Nơi kết nối đam mê tennis.", "footer.explore": "Khám phá", "footer.contact": "Liên hệ", "footer.address": "TP. Hồ Chí Minh", "footer.rights": "Bảo lưu mọi quyền.",
        "booking.eyebrow": "ĐẶT LỊCH", "booking.title": "Đặt sân tennis", "booking.description": "Chọn ngày, loại lớp và khung giờ phù hợp với bạn.", "booking.formTitle": "Thông tin đặt sân", "booking.name": "Họ và tên", "booking.phone": "Số điện thoại", "booking.note": "Ghi chú", "booking.submit": "Gửi yêu cầu đặt sân", "booking.cancel": "Hủy", "booking.weeklyTitle": "Đặt lịch", "booking.weeklyDescription": "Điền thông tin để đăng ký lịch học trong tuần.", "booking.weeklyGroup": "Đặt cho cả tuần", "booking.weeklySuccess": "Thông tin của bạn đã được ghi nhận.", "booking.weeklyError": "Vui lòng chọn ít nhất một ngày.", "booking.helpTitle": "Bạn cần hỗ trợ?", "booking.helpText": "Đội ngũ ACE sẽ liên hệ để xác nhận sân và khung giờ của bạn.",
        "about.eyebrow": "ACE TENNIS ACADEMY", "about.title": "Về chúng tôi", "about.description": "Không gian luyện tập chuyên nghiệp cho mọi trình độ.", "about.heading": "Tennis cho mọi người", "about.text": "ACE Tennis Academy kết nối huấn luyện viên giàu kinh nghiệm với cộng đồng người yêu tennis tại TP.HCM.", "coach.eyebrow": "ĐỘI NGŨ ACE", "coach.title": "Huấn luyện viên", "coach.description": "Gặp gỡ những người đồng hành giúp bạn chơi tốt hơn mỗi ngày.", "coach.sectionEyebrow": "ĐỒNG HÀNH CÙNG BẠN", "coach.sectionTitle": "Kinh nghiệm thật, lộ trình phù hợp", "coach.sectionDescription": "Mỗi huấn luyện viên tại ACE mang đến một thế mạnh riêng, cùng chung mục tiêu giúp học viên tiến bộ bền vững.", "coach.certificates": "Chứng chỉ", "coach.achievements": "Thành tựu", "coach.introduction": "Giới thiệu",
        "privacy.eyebrow": "THÔNG TIN", "privacy.title": "Chính sách bảo mật", "privacy.description": "Thông tin của bạn được sử dụng để hỗ trợ việc đặt sân.", "privacy.heading": "Quyền riêng tư của bạn", "privacy.text": "Chúng tôi chỉ sử dụng thông tin cần thiết để xác nhận lịch đặt và hỗ trợ khách hàng.",
        "news.eyebrow": "TIN TỨC", "news.tournamentTitle": "Giải đấu", "news.tournamentDescription": "Cập nhật các giải đấu và hoạt động thi đấu tại ACE.", "news.tournamentCard": "ACE Community Cup", "news.tournamentText": "Giải đấu giao lưu dành cho người chơi ở nhiều trình độ.", "news.trainingTitle": "Sân tập", "news.trainingDescription": "Không gian luyện tập chất lượng cho từng buổi học.", "news.trainingCard": "Sân tập chuẩn thi đấu", "news.trainingText": "Mặt sân được chăm sóc định kỳ để mang lại trải nghiệm ổn định.", "news.promotionTitle": "Khuyến mãi", "news.promotionDescription": "Ưu đãi mới dành cho học viên và khách hàng của ACE.", "news.promotionCard": "Ưu đãi học viên mới", "news.promotionText": "Đăng ký buổi học đầu tiên để nhận tư vấn lộ trình phù hợp."
    },
    en: {
        "nav.home": "Home", "nav.booking": "Book a court", "nav.coaches": "Coaches", "nav.news": "News",
        "nav.tournament": "Tournaments", "nav.training": "Training courts", "nav.promotion": "Promotions",
        "nav.about": "About us", "language.vietnamese": "VN", "language.english": "ENG",
        "page.title": "TennisBooking", "footer.privacy": "Privacy", "home.title": "WELCOME TO ACE TENNIS ACADEMY",
        "home.subtitle": "Professional Tennis Coaching in HCMC", "home.customers": "Customers who trust us",
        "home.bookNow": "Book now", "schedule.eyebrow": "FLEXIBLE SCHEDULE",
        "schedule.title": "Choose a training time", "schedule.description": "Choose a start and end time to select the period you want to book.",
        "schedule.date": "Training date", "schedule.classType": "Class type", "schedule.private": "Private class",
        "schedule.group": "Group class", "schedule.kids": "Kids class", "schedule.selected": "Selected time",
        "schedule.none": "No time selected", "schedule.start": "Choose a start time", "schedule.end": "Choose an end time",
        "schedule.note": "Opening hours: 08:00–22:00 · Select in 1-hour intervals", "nav.toggle": "Toggle navigation",
        "footer.tagline": "Where tennis passion comes together.", "footer.explore": "Explore", "footer.contact": "Contact", "footer.address": "Ho Chi Minh City", "footer.rights": "All rights reserved.",
        "booking.eyebrow": "BOOKING", "booking.title": "Book a tennis court", "booking.description": "Choose a date, class type and time that works for you.", "booking.formTitle": "Booking details", "booking.name": "Full name", "booking.phone": "Phone number", "booking.note": "Notes", "booking.submit": "Send booking request", "booking.cancel": "Cancel", "booking.weeklyTitle": "Book a schedule", "booking.weeklyDescription": "Enter your details to register a training schedule for the week.", "booking.weeklyGroup": "Book for the whole week", "booking.weeklySuccess": "Your information has been received.", "booking.weeklyError": "Please select at least one day.", "booking.helpTitle": "Need help?", "booking.helpText": "The ACE team will contact you to confirm your court and time.",
        "about.eyebrow": "ACE TENNIS ACADEMY", "about.title": "About us", "about.description": "Professional training space for every level.", "about.heading": "Tennis for everyone", "about.text": "ACE Tennis Academy connects experienced coaches with the tennis community in Ho Chi Minh City.", "coach.eyebrow": "THE ACE TEAM", "coach.title": "Coaches", "coach.description": "Meet the people who help you play better every day.", "coach.sectionEyebrow": "YOUR TEAMMATES", "coach.sectionTitle": "Real experience, the right path", "coach.sectionDescription": "Every ACE coach brings a distinct strength and the same goal: sustainable progress for every student.", "coach.certificates": "Certificates", "coach.achievements": "Achievements", "coach.introduction": "Introduction",
        "privacy.eyebrow": "INFORMATION", "privacy.title": "Privacy policy", "privacy.description": "Your information is used to support court bookings.", "privacy.heading": "Your privacy", "privacy.text": "We only use the information needed to confirm bookings and support customers.",
        "news.eyebrow": "NEWS", "news.tournamentTitle": "Tournaments", "news.tournamentDescription": "Updates on tournaments and competitions at ACE.", "news.tournamentCard": "ACE Community Cup", "news.tournamentText": "A friendly tournament for players of different levels.", "news.trainingTitle": "Training courts", "news.trainingDescription": "A quality training space for every session.", "news.trainingCard": "Competition-ready courts", "news.trainingText": "Our courts are maintained regularly for a consistent experience.", "news.promotionTitle": "Promotions", "news.promotionDescription": "New offers for ACE students and customers.", "news.promotionCard": "New student offer", "news.promotionText": "Book your first session and receive a tailored training consultation."
    }
};

let currentLanguage = localStorage.getItem("tennis-language") || "vi";

const translatePage = (language) => {
    currentLanguage = translations[language] ? language : "vi";
    localStorage.setItem("tennis-language", currentLanguage);
    document.documentElement.lang = currentLanguage;
    document.title = `${translations[currentLanguage]["page.title"]} - TennisBooking`;
    document.querySelectorAll("[data-i18n]").forEach((element) => {
        const value = translations[currentLanguage][element.dataset.i18n];
        if (value) element.textContent = value;
    });
    const menuToggle = document.querySelector(".navbar-toggler");
    if (menuToggle) menuToggle.setAttribute("aria-label", translations[currentLanguage]["nav.toggle"]);
    const languageLabel = document.querySelector("#languageDropdown");
    if (languageLabel) languageLabel.childNodes[0].textContent = currentLanguage === "vi" ? "VN" : "ENG";
    document.dispatchEvent(new CustomEvent("languageChanged", { detail: currentLanguage }));
};

window.translatePage = translatePage;

document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll("[data-scroll-to]").forEach((button) => {
        button.addEventListener("click", () => {
            const target = document.querySelector(button.dataset.scrollTo);
            if (!target) return;

            target.scrollIntoView({ behavior: "smooth", block: "start" });
            window.setTimeout(() => target.querySelector("#schedule-date")?.focus(), 450);
        });
    });

    document.querySelectorAll("[data-language]").forEach((option) => {
        option.addEventListener("click", (event) => {
            event.preventDefault();
            translatePage(option.dataset.language);
        });
    });
    translatePage(currentLanguage);
});

document.addEventListener("DOMContentLoaded", () => {
    const dateInput = document.querySelector("#schedule-date");
    const classInput = document.querySelector("#schedule-class");
    const hours = [...document.querySelectorAll(".schedule-hour")];
    const selection = document.querySelector("#schedule-selection");
    const status = document.querySelector("#schedule-status");
    const scheduleButton = document.querySelector("#schedule-booking-btn");

    if (!dateInput || !classInput || !hours.length || !selection || !status || !scheduleButton) {
        return;
    }

    let startHour = null;
    let endHour = null;
    let bookedSlots = [];

    const today = new Date();
    dateInput.value = `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`;

    const formatHour = (hour) => `${String(hour).padStart(2, "0")}:00`;
    const getWeekStart = (dateValue) => {
        const date = new Date(`${dateValue}T12:00:00`);
        const day = date.getDay();
        date.setDate(date.getDate() + (day === 0 ? -6 : 1 - day));
        return `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, "0")}-${String(date.getDate()).padStart(2, "0")}`;
    };

    const getBookingDates = () => {
        const dates = [...document.querySelectorAll("input[name='bookingDays']:checked")].map((input) => input.value);
        return dates.length > 0 ? dates : [dateInput.value];
    };

    const refreshAvailability = async () => {
        try {
            const response = await fetch(`/Booking/Availability?weekStart=${getWeekStart(dateInput.value)}&classType=${encodeURIComponent(classInput.value)}`);
            if (!response.ok) throw new Error("availability-request-failed");
            const data = await response.json();
            bookedSlots = (data.bookedSlots || []).map((slot) => slot.slice(0, 19));
            window.bookingAvailability = { bookedSlots };
            renderSelection();
            document.dispatchEvent(new CustomEvent("bookingAvailabilityChanged"));
        } catch (error) {
            console.error("Unable to load booking availability.", error);
        }
    };

    const resetSelection = () => {
        startHour = null;
        endHour = null;
        hours.forEach((hour) => {
            hour.classList.remove("is-start", "is-end", "is-selected");
            hour.setAttribute("aria-pressed", "false");
        });
        selection.textContent = translations[currentLanguage]["schedule.none"];
        status.textContent = translations[currentLanguage]["schedule.start"];
        scheduleButton.disabled = true;
        delete scheduleButton.dataset.startHour;
        delete scheduleButton.dataset.endHour;
        renderSelection();
    };

    const renderSelection = () => {
        const rangeAvailable = startHour !== null
            && endHour !== null
            && (window.bookingValidation?.isRangeAvailableForDates(bookedSlots, getBookingDates(), startHour, endHour) ?? true);
        scheduleButton.disabled = !rangeAvailable;
        if (startHour === null || endHour === null) {
            delete scheduleButton.dataset.startHour;
            delete scheduleButton.dataset.endHour;
        } else {
            scheduleButton.dataset.startHour = String(startHour);
            scheduleButton.dataset.endHour = String(endHour);
        }
        hours.forEach((button) => {
            const hour = Number(button.dataset.hour);
            const isBooked = window.bookingValidation?.isSlotBooked(bookedSlots, dateInput.value, hour) ?? false;
            const selected = startHour !== null && endHour !== null && hour >= startHour && hour <= endHour;
            button.disabled = isBooked;
            button.classList.toggle("is-booked", isBooked);
            button.classList.toggle("is-selected", selected);
            button.classList.toggle("is-start", hour === startHour);
            button.classList.toggle("is-end", hour === endHour);
            button.setAttribute("aria-pressed", String(selected || hour === startHour));
            button.setAttribute("aria-disabled", String(isBooked));
        });

        if (startHour === null) {
            selection.textContent = translations[currentLanguage]["schedule.none"];
            status.textContent = translations[currentLanguage]["schedule.start"];
        } else if (endHour === null) {
            selection.textContent = `${formatHour(startHour)} – ...`;
            status.textContent = translations[currentLanguage]["schedule.end"];
        } else {
            selection.textContent = `${formatHour(startHour)} – ${formatHour(endHour)}`;
            status.textContent = `${classInput.options[classInput.selectedIndex].text} · ${dateInput.value}`;
        }
    };

    hours.forEach((button) => {
        button.addEventListener("click", () => {
            if (button.disabled) return;
            const hour = Number(button.dataset.hour);

            if (startHour === null || endHour !== null) {
                startHour = hour;
                endHour = null;
            } else {
                endHour = hour;
                if (endHour < startHour) {
                    [startHour, endHour] = [endHour, startHour];
                }
            }

            renderSelection();
            document.dispatchEvent(new CustomEvent("scheduleTimeChanged"));
        });
    });

    dateInput.addEventListener("change", () => {
        resetSelection();
        refreshAvailability();
        document.dispatchEvent(new CustomEvent("scheduleTimeChanged"));
    });
    classInput.addEventListener("change", () => {
        resetSelection();
        refreshAvailability();
        document.dispatchEvent(new CustomEvent("scheduleTimeChanged"));
    });
    document.addEventListener("languageChanged", renderSelection);
    renderSelection();
    refreshAvailability();
    document.addEventListener("bookingCreated", refreshAvailability);
    document.addEventListener("bookingDaysChanged", renderSelection);
});

document.addEventListener("DOMContentLoaded", () => {
    const weekOptions = document.querySelector("#bookingWeekOptions");
    const bookingForm = document.querySelector("#weeklyBookingForm");
    const successMessage = document.querySelector("#weeklyBookingSuccess");
    const errorMessage = document.querySelector("#weeklyBookingError");
    const submitButton = document.querySelector("#weeklyBookingSubmit");

    if (!weekOptions || !bookingForm || !successMessage || !errorMessage || !submitButton || !window.bookingWeek || !window.bookingValidation) {
        return;
    }

    const selectedDays = () => [...weekOptions.querySelectorAll("input[name='bookingDays']:checked")].map((input) => input.value);
    let bookedSlots = window.bookingAvailability?.bookedSlots || [];

    const updateSubmitState = () => {
        submitButton.disabled = !window.bookingValidation.isBookingReady({
            name: document.querySelector("#weeklyBookingName")?.value,
            phone: document.querySelector("#weeklyBookingPhone")?.value,
            selectedDays: selectedDays(),
            startHour: Number(document.querySelector("#schedule-booking-btn")?.dataset.startHour) || null,
            endHour: Number(document.querySelector("#schedule-booking-btn")?.dataset.endHour) || null
        });
    };

    const renderBookingWeek = () => {
        const today = new Date();
        const days = window.bookingWeek.buildBookingWeek(today);
        const formatter = new Intl.DateTimeFormat(currentLanguage === "vi" ? "vi-VN" : "en-US", {
            weekday: "long",
            day: "2-digit",
            month: "2-digit"
        });

        const scheduleButton = document.querySelector("#schedule-booking-btn");
        const startHour = Number(scheduleButton?.dataset.startHour);
        const endHour = Number(scheduleButton?.dataset.endHour);
        const hasSelectedRange = Number.isInteger(startHour) && Number.isInteger(endHour);

        weekOptions.innerHTML = days.map((day) => {
            const date = new Date(`${day.date}T12:00:00`);
            const unavailable = hasSelectedRange
                && !window.bookingValidation.isRangeAvailable(bookedSlots, day.date, startHour, endHour);
            const disabledClass = day.disabled || unavailable ? " is-disabled" : "";
            const disabledAttribute = day.disabled || unavailable ? " disabled" : "";
            const checkedAttribute = day.checked && !unavailable ? " checked" : "";

            return `<label class="booking-week-option${disabledClass}">
                <input type="checkbox" name="bookingDays" value="${day.date}"${checkedAttribute}${disabledAttribute}>
                <span>${formatter.format(date)}</span>
            </label>`;
        }).join("");
        weekOptions.querySelectorAll("input[name='bookingDays']").forEach((input) => input.addEventListener("change", () => {
            updateSubmitState();
            document.dispatchEvent(new CustomEvent("bookingDaysChanged"));
        }));
        updateSubmitState();
        document.dispatchEvent(new CustomEvent("bookingDaysChanged"));
    };

    bookingForm.addEventListener("submit", async (event) => {
        event.preventDefault();
        if (!bookingForm.checkValidity()) {
            bookingForm.reportValidity();
            return;
        }

        if (selectedDays().length === 0) {
            errorMessage.textContent = translations[currentLanguage]["booking.weeklyError"];
            errorMessage.classList.remove("d-none");
            return;
        }

        const scheduleButton = document.querySelector("#schedule-booking-btn");
        const payload = window.bookingValidation.buildBookingPayload(
            document.querySelector("#weeklyBookingName").value,
            document.querySelector("#weeklyBookingPhone").value,
            selectedDays(),
            Number(scheduleButton?.dataset.startHour),
            Number(scheduleButton?.dataset.endHour),
            document.querySelector("#schedule-class")?.value
        );

        errorMessage.classList.add("d-none");
        try {
            const response = await fetch("/Booking/Create", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(payload)
            });
            const result = await response.json().catch(() => ({}));
            if (!response.ok) {
                throw new Error(result.message || translations[currentLanguage]["booking.weeklyError"]);
            }

            successMessage.classList.remove("d-none");
            document.dispatchEvent(new CustomEvent("bookingCreated"));
        } catch (error) {
            errorMessage.textContent = error.message;
            errorMessage.classList.remove("d-none");
        }
    });

    bookingForm.querySelectorAll("input").forEach((input) => input.addEventListener("input", updateSubmitState));

    document.querySelector("#weeklyBookingModal")?.addEventListener("show.bs.modal", () => {
        renderBookingWeek();
        errorMessage.classList.add("d-none");
        successMessage.classList.add("d-none");
    });

    document.addEventListener("languageChanged", renderBookingWeek);
    document.addEventListener("bookingAvailabilityChanged", (event) => {
        bookedSlots = event.detail?.bookedSlots || window.bookingAvailability?.bookedSlots || [];
        renderBookingWeek();
    });
    document.addEventListener("scheduleTimeChanged", renderBookingWeek);
    renderBookingWeek();
});
