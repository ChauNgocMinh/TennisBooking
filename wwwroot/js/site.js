// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const translations = {
    vi: {
        "home.newsEyebrow": "TIN TỨC TỪ ACE", "home.newsTitle": "Tin mới nhất", "home.newsLink": "Xem tất cả", "home.aboutEyebrow": "VỀ ACE TENNIS ACADEMY", "home.aboutTitle": "Một đội ngũ đáng tin cậy cho hành trình tennis của bạn", "home.aboutText": "ACE Tennis Academy được xây dựng với mong muốn đưa việc học tennis trở nên rõ ràng, gần gũi và bền vững hơn cho mọi trình độ. Chúng tôi tin rằng tennis không chỉ là một môn thể thao, mà còn là hành trình rèn luyện sức khỏe, sự kiên trì, khả năng tập trung và tinh thần vượt qua giới hạn của chính mình.", "home.yearsValue": "Nhiều năm", "home.yearsLabel": "đồng hành cùng tennis", "home.customersValue": "500+", "home.customersLabel": "học viên đã tin tưởng", "home.trustValue": "4.9/5", "home.trustLabel": "mức độ tin cậy từ học viên", "home.aboutLink": "Tìm hiểu về ACE",
        "admin.visual": "Hình ảnh", "admin.visualHint": "Chọn banner tạo ấn tượng đầu tiên cho bài viết.", "admin.imageUpload": "Ảnh huấn luyện viên", "admin.imageHint": "JPG, PNG, WEBP hoặc GIF, tối đa 5 MB.", "admin.imageRequired": "Vui lòng chọn ảnh huấn luyện viên.", "admin.currentImage": "Ảnh hiện tại",
        "nav.home": "Trang chủ", "nav.booking": "Đặt sân", "nav.coaches": "Huấn luyện viên", "nav.news": "Tin tức",
        "nav.newsIndex": "Tất cả tin tức", "nav.tournament": "Giải đấu", "nav.training": "Sân tập", "nav.promotion": "Khuyến mãi",
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
        "about.approachText": "Mỗi buổi học có mục tiêu rõ ràng. Lộ trình được điều chỉnh theo thể lực, trình độ và mong muốn riêng, giúp học viên tiến bộ và duy trì niềm yêu thích tennis lâu dài.",
        "about.storyText": "ACE Tennis Academy được xây dựng với mong muốn đưa việc học tennis trở nên rõ ràng, gần gũi và bền vững hơn cho mọi trình độ. Chúng tôi tin rằng tennis không chỉ là một môn thể thao, mà còn là hành trình rèn luyện sức khỏe, sự kiên trì, khả năng tập trung và tinh thần vượt qua giới hạn của chính mình.",
        "about.storyTextTwo": "Từ những buổi tập đầu tiên đến các mục tiêu thi đấu dài hạn, đội ngũ ACE luôn đồng hành cùng học viên bằng giáo án phù hợp, phản hồi cụ thể và một môi trường luyện tập tích cực. Mỗi học viên đều có tốc độ phát triển khác nhau, vì vậy chương trình tại ACE không áp dụng một lộ trình cố định cho tất cả mọi người.",

        "about.philosophyTitle": "Tennis dành cho tất cả mọi người",
        "about.philosophyText": "Dù bạn chưa từng cầm vợt, đang muốn cải thiện kỹ thuật hay hướng đến những giải đấu chuyên nghiệp hơn, ACE Tennis Academy đều xây dựng chương trình học dựa trên mục tiêu thực tế của bạn. Điều quan trọng nhất không phải là bạn bắt đầu ở trình độ nào, mà là bạn có một lộ trình phù hợp để tiến bộ từng ngày.",
        "about.philosophyTextTwo": "Trong những buổi đầu tiên, huấn luyện viên sẽ quan sát khả năng vận động, kỹ thuật hiện tại, thể lực và mục tiêu của học viên. Từ đó, chương trình luyện tập được thiết kế với các nội dung phù hợp như footwork, forehand, backhand, volley, serve, khả năng kiểm soát bóng và tư duy xử lý tình huống trên sân.",

        "about.coachApproachText": "Huấn luyện viên theo sát quá trình luyện tập để nhận ra những điểm cần điều chỉnh từ sớm. Những lỗi nhỏ về tư thế, cách cầm vợt, vị trí tiếp xúc bóng hoặc di chuyển chân nếu được sửa đúng thời điểm sẽ giúp học viên hình thành nền tảng tốt hơn và hạn chế những thói quen kỹ thuật không phù hợp về lâu dài.",

        "about.trainingTitle": "Lộ trình luyện tập có mục tiêu rõ ràng",
        "about.trainingText": "Thay vì luyện tập một cách ngẫu nhiên, chương trình được chia thành từng giai đoạn. Học viên bắt đầu từ việc xây dựng nền tảng kỹ thuật, sau đó phát triển khả năng kiểm soát bóng, di chuyển, phối hợp các kỹ thuật và cuối cùng là áp dụng chúng vào tình huống thi đấu.",
        "about.trainingTextTwo": "Đối với những học viên đã có kinh nghiệm, giáo án có thể tập trung sâu hơn vào chiến thuật, khả năng điều tiết nhịp độ trận đấu, lựa chọn cú đánh, cải thiện điểm yếu và phát triển phong cách chơi phù hợp với từng cá nhân.",

        "about.environmentTitle": "Một môi trường để bạn tự tin tiến bộ",
        "about.environmentText": "ACE mong muốn tạo ra một môi trường mà học viên có thể thoải mái học, thử nghiệm và sửa sai. Trong thể thao, sai sót là một phần tự nhiên của quá trình phát triển. Vì vậy, chúng tôi khuyến khích học viên tập trung vào sự tiến bộ thay vì tạo áp lực phải hoàn hảo ngay từ những buổi đầu tiên.",
        "about.environmentTextTwo": "Bên cạnh kỹ thuật, ACE chú trọng đến trải nghiệm của học viên trong mỗi buổi tập. Một buổi học hiệu quả cần có sự cân bằng giữa tính chuyên môn, cường độ luyện tập và cảm giác hứng thú để học viên có động lực tiếp tục quay lại sân.",

        "about.communityTitle": "Không chỉ là nơi học tennis",
        "about.communityText": "ACE Tennis Academy hướng đến việc xây dựng một cộng đồng nơi những người có chung niềm yêu thích tennis có thể gặp gỡ, luyện tập và cùng nhau phát triển. Tennis trở nên thú vị hơn khi bạn có những người bạn có thể cùng tập luyện, chia sẻ kinh nghiệm và tạo động lực cho nhau.",
        "about.communityTextTwo": "Thông qua các buổi luyện tập nhóm, hoạt động giao lưu và những trận đấu thực tế, học viên có thêm cơ hội áp dụng kỹ thuật đã học, nâng cao khả năng phản xạ và làm quen với nhiều phong cách chơi khác nhau.",

        "about.childrenTitle": "Xây dựng nền tảng tennis cho học viên trẻ",
        "about.childrenText": "Với học viên trẻ, ACE đặc biệt chú trọng đến việc xây dựng nền tảng vận động và tạo cảm giác yêu thích thể thao. Các bài tập được thiết kế phù hợp với độ tuổi, kết hợp giữa kỹ thuật tennis, khả năng phối hợp, phản xạ và những hoạt động giúp buổi học trở nên sinh động hơn.",
        "about.childrenTextTwo": "Mục tiêu không chỉ là giúp các em đánh bóng tốt hơn mà còn phát triển tính kỷ luật, sự tự tin, khả năng tập trung và tinh thần thể thao. Đây là những giá trị có thể đồng hành cùng học viên cả trong và ngoài sân tennis.",

        "about.performanceTitle": "Dành cho những mục tiêu cao hơn",
        "about.performanceText": "Với học viên muốn nâng cao trình độ hoặc chuẩn bị cho thi đấu, ACE xây dựng chương trình tập trung vào hiệu suất. Các buổi tập có thể bao gồm drill cường độ cao, xử lý tình huống, chiến thuật thi đấu, khả năng duy trì thể lực và kiểm soát tâm lý trong những thời điểm quan trọng của trận đấu.",
        "about.performanceTextTwo": "Quá trình luyện tập được đánh giá thường xuyên để xác định những điểm đã cải thiện và những yếu tố cần tiếp tục phát triển. Điều này giúp học viên hiểu rõ tiến độ của mình thay vì chỉ dựa vào cảm giác sau mỗi buổi tập.",

        "about.valuesText": "Chúng tôi đặt chất lượng chuyên môn, sự tôn trọng và tính nhất quán làm nền tảng trong quá trình đào tạo. ACE tin rằng kết quả bền vững đến từ việc thực hiện đúng những điều cơ bản trong thời gian đủ dài, thay vì tìm kiếm những phương pháp cải thiện nhanh nhưng thiếu nền tảng.",
        "about.valuesTextTwo": "Mỗi học viên đều được khuyến khích đặt mục tiêu, theo dõi quá trình tiến bộ và chủ động trao đổi với huấn luyện viên. Sự phối hợp giữa người học và người hướng dẫn giúp quá trình luyện tập hiệu quả hơn và tạo ra những thay đổi có thể quan sát được theo thời gian.",

        "about.experienceTitle": "Mỗi buổi tập là một bước tiến",
        "about.experienceText": "Sự tiến bộ trong tennis không diễn ra chỉ sau một vài buổi tập. Đó là kết quả của hàng trăm lần lặp lại một động tác, những lần đánh bóng chưa chính xác, những điều chỉnh nhỏ và sự kiên trì theo thời gian. ACE sẽ đồng hành để quá trình đó trở nên rõ ràng và có định hướng hơn.",

        "about.commitmentTitle": "Cam kết của ACE Tennis Academy",
        "about.commitmentText": "ACE cam kết tiếp tục hoàn thiện chất lượng đào tạo, phương pháp huấn luyện và trải nghiệm học viên. Chúng tôi luôn lắng nghe phản hồi để điều chỉnh chương trình, cải thiện cách tổ chức lớp học và mang đến môi trường luyện tập ngày càng chuyên nghiệp hơn.",
        "about.commitmentTextTwo": "Dù mục tiêu của bạn là học tennis từ đầu, nâng cao sức khỏe, tìm một hoạt động thể thao lâu dài hay hướng đến thi đấu, ACE Tennis Academy mong muốn trở thành nơi bạn có thể bắt đầu và tiếp tục hành trình đó một cách tự tin.",

        "about.finalTitle": "Cùng ACE bắt đầu hành trình của bạn",
        "about.finalText": "Một cây vợt, một sân tennis và một mục tiêu rõ ràng có thể là khởi đầu cho một hành trình dài. ACE Tennis Academy sẵn sàng đồng hành cùng bạn từ những cú đánh đầu tiên cho đến những cột mốc lớn hơn trong tương lai.",
        "privacy.eyebrow": "THÔNG TIN", "privacy.title": "Chính sách bảo mật", "privacy.description": "Thông tin của bạn được sử dụng để hỗ trợ việc đặt sân.", "privacy.heading": "Quyền riêng tư của bạn", "privacy.text": "Chúng tôi chỉ sử dụng thông tin cần thiết để xác nhận lịch đặt và hỗ trợ khách hàng.",
        "news.eyebrow": "TIN TỨC", "news.indexTitle": "Tin tức mới nhất", "news.indexDescription": "Cập nhật những hoạt động và thông tin mới nhất từ ACE.", "news.viewDetails": "Xem chi tiết", "news.readMore": "Đọc bài viết", "news.latestLabel": "MỚI NHẤT", "news.backToNews": "Quay lại tin tức", "news.relatedTitle": "Tin tức liên quan", "news.tournamentTitle": "Giải đấu", "news.tournamentDescription": "Cập nhật các giải đấu và hoạt động thi đấu tại ACE.", "news.tournamentCard": "ACE Community Cup", "news.tournamentText": "Giải đấu giao lưu dành cho người chơi ở nhiều trình độ.", "news.trainingTitle": "Sân tập", "news.trainingDescription": "Không gian luyện tập chất lượng cho từng buổi học.", "news.trainingCard": "Sân tập chuẩn thi đấu", "news.trainingText": "Mặt sân được chăm sóc định kỳ để mang lại trải nghiệm ổn định.", "news.promotionTitle": "Khuyến mãi", "news.promotionDescription": "Ưu đãi mới dành cho học viên và khách hàng của ACE.", "news.promotionCard": "Ưu đãi học viên mới", "news.promotionText": "Đăng ký buổi học đầu tiên để nhận tư vấn lộ trình phù hợp.",
        "admin.kicker": "ACE TENNIS ACADEMY", "admin.panel": "Bảng quản trị", "admin.dashboard": "Tổng quan", "admin.dashboardTitle": "Tổng quan", "admin.courts": "Sân tennis", "admin.coaches": "Huấn luyện viên", "admin.news": "Tin tức", "admin.logout": "Đăng xuất", "admin.loginTitle": "Đăng nhập quản trị", "admin.loginDescription": "Đăng nhập để quản lý học viện tennis.", "admin.email": "Email", "admin.password": "Mật khẩu", "admin.login": "Đăng nhập", "admin.loginInvalid": "Email hoặc mật khẩu không đúng.", "admin.add": "Thêm mới", "admin.edit": "Sửa", "admin.delete": "Xóa", "admin.save": "Lưu", "admin.cancel": "Hủy", "admin.name": "Tên", "admin.type": "Loại sân", "admin.price": "Giá", "admin.description": "Mô tả", "admin.experience": "Kinh nghiệm", "admin.imageUrl": "URL hình ảnh", "admin.certificates": "Chứng chỉ", "admin.achievements": "Thành tựu", "admin.introduction": "Giới thiệu", "admin.titleVi": "Tiêu đề tiếng Việt", "admin.titleEn": "Tiêu đề tiếng Anh", "admin.publishedAt": "Ngày đăng", "admin.shortContentVi": "Mô tả ngắn tiếng Việt", "admin.shortContentEn": "Mô tả ngắn tiếng Anh", "admin.bannerImage": "Ảnh banner", "admin.bannerHint": "JPG, PNG, WEBP hoặc GIF, tối đa 5 MB.", "admin.bannerRequired": "Vui lòng chọn ảnh banner.", "admin.currentBanner": "Banner hiện tại", "admin.contentVi": "Nội dung tiếng Việt", "admin.contentEn": "Nội dung tiếng Anh", "admin.newsKicker": "CONTENT STUDIO", "admin.newsForm": "Thông tin bài viết", "admin.newsFormDescription": "Tạo một bài viết rõ ràng, trực quan cho cộng đồng ACE.", "admin.draft": "BẢN NHÁP", "admin.storyBasics": "Thông tin cơ bản", "admin.storyBasicsHint": "Thiết lập tiêu đề và phần mô tả hiển thị trên trang tin tức.", "admin.visualDate": "Hình ảnh và ngày đăng", "admin.visualDateHint": "Chọn banner tạo ấn tượng đầu tiên cho bài viết.", "admin.storyContent": "Nội dung bài viết", "admin.storyContentHint": "Định dạng chữ, thêm liên kết, danh sách và hình ảnh bằng trình soạn thảo.", "admin.courtForm": "Thông tin sân", "admin.coachForm": "Thông tin huấn luyện viên", "admin.deleteConflict": "Không thể xóa dữ liệu đang được sử dụng.", "admin.linkPrompt": "Nhập URL liên kết", "admin.imagePrompt": "Nhập URL hình ảnh"
    },
    en: {
        "home.newsEyebrow": "FROM ACE", "home.newsTitle": "The news", "home.newsLink": "View all", "home.aboutEyebrow": "ABOUT ACE TENNIS ACADEMY", "home.aboutTitle": "A trusted team for your tennis journey", "home.aboutText": "ACE Tennis Academy was created to make learning tennis clearer, more welcoming, and more sustainable for players of every level. We believe tennis is more than a sport; it is also a journey of improving fitness, persistence, concentration, and the confidence to push beyond your own limits.", "home.yearsValue": "Many years", "home.yearsLabel": "of tennis experience", "home.customersValue": "500+", "home.customersLabel": "students who trust us", "home.trustValue": "4.9/5", "home.trustLabel": "student trust rating", "home.aboutLink": "Discover ACE",
        "admin.visual": "Visual", "admin.visualHint": "Choose a banner that gives the story a strong first impression.", "admin.imageUpload": "Trainer image", "admin.imageHint": "JPG, PNG, WEBP or GIF, up to 5 MB.", "admin.imageRequired": "Please select a trainer image.", "admin.currentImage": "Current image",
        "nav.home": "Home", "nav.booking": "Book a court", "nav.coaches": "Coaches", "nav.news": "News",
        "nav.newsIndex": "All news", "nav.tournament": "Tournaments", "nav.training": "Training courts", "nav.promotion": "Promotions",
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
        "about.approachText": "Every session has a clear goal. Training plans adapt to each student's fitness, level, and ambitions, helping them improve while building a lasting enjoyment of tennis.",

        "about.storyText": "ACE Tennis Academy was created to make learning tennis clearer, more welcoming, and more sustainable for players of every level. We believe tennis is more than a sport; it is also a journey of improving fitness, persistence, concentration, and the confidence to push beyond your own limits.",
        "about.storyTextTwo": "From the first training sessions to long-term competition goals, the ACE team supports every student with a suitable training plan, specific feedback, and a positive training environment. Every player develops at a different pace, so ACE does not apply the same fixed pathway to everyone.",

        "about.philosophyTitle": "Tennis for everyone",
        "about.philosophyText": "Whether you have never held a racket before, want to improve your technique, or are working toward more competitive goals, ACE Tennis Academy builds each training program around your actual objectives. What matters most is not where you start, but having the right path to keep improving step by step.",
        "about.philosophyTextTwo": "During the first sessions, our coaches assess each student's movement, current technique, fitness level, and personal goals. From there, the training plan can cover areas such as footwork, forehand, backhand, volleys, serves, ball control, and decision-making in real match situations.",

        "about.coachApproachText": "Our coaches closely follow each student's progress so adjustments can be made early. Small issues with posture, grip, contact point, or footwork can become long-term habits if left uncorrected, so timely feedback helps students build a stronger technical foundation.",

        "about.trainingTitle": "A training path with clear goals",
        "about.trainingText": "Instead of training randomly, each program is divided into structured stages. Students begin by developing fundamental technique, then improve ball control, movement, technical combinations, and eventually learn how to apply those skills in real match situations.",
        "about.trainingTextTwo": "For more experienced players, training can focus more deeply on tactics, controlling the tempo of a match, shot selection, addressing weaknesses, and developing a playing style that suits the individual.",

        "about.environmentTitle": "An environment where you can improve with confidence",
        "about.environmentText": "ACE aims to create an environment where students feel comfortable learning, experimenting, and making mistakes. In sport, mistakes are a natural part of development. We therefore encourage students to focus on progress rather than putting pressure on themselves to be perfect from the beginning.",
        "about.environmentTextTwo": "Beyond technique, ACE also focuses on the overall training experience. An effective session should balance professional instruction, training intensity, and enjoyment so students remain motivated to return to the court.",

        "about.communityTitle": "More than just a place to learn tennis",
        "about.communityText": "ACE Tennis Academy aims to build a community where people who share a passion for tennis can meet, train, and grow together. Tennis becomes even more enjoyable when you have people to practice with, exchange experiences with, and motivate each other.",
        "about.communityTextTwo": "Through group sessions, community activities, and real match play, students have more opportunities to apply what they have learned, improve their reactions, and experience different playing styles.",

        "about.childrenTitle": "Building strong tennis foundations for young players",
        "about.childrenText": "For younger students, ACE places special emphasis on developing fundamental movement skills and a genuine enjoyment of sport. Training activities are designed to suit each age group and combine tennis technique, coordination, reaction skills, and engaging exercises.",
        "about.childrenTextTwo": "The goal is not only to help young players hit the ball better, but also to develop discipline, confidence, concentration, and sportsmanship. These are valuable skills that can support students both on and off the tennis court.",

        "about.performanceTitle": "For players with bigger goals",
        "about.performanceText": "For students who want to reach a higher level or prepare for competition, ACE provides performance-focused training. Sessions may include high-intensity drills, tactical situations, match strategy, physical endurance, and mental control during important moments in a match.",
        "about.performanceTextTwo": "Progress is reviewed regularly to identify what has improved and what still requires further development. This helps students clearly understand their progress instead of relying only on how they feel after each session.",

        "about.valuesText": "We place professional quality, respect, and consistency at the core of our training approach. ACE believes sustainable results come from repeatedly doing the fundamentals well over time rather than searching for quick improvements without a strong foundation.",
        "about.valuesTextTwo": "Every student is encouraged to set goals, follow their own progress, and communicate openly with their coach. Strong collaboration between student and coach makes training more effective and helps create measurable improvement over time.",

        "about.experienceTitle": "Every session is a step forward",
        "about.experienceText": "Progress in tennis does not happen after only a few sessions. It comes from hundreds of repetitions, missed shots, small technical adjustments, and consistent effort over time. ACE is here to make that process clearer, more structured, and more purposeful.",

        "about.commitmentTitle": "Our commitment at ACE Tennis Academy",
        "about.commitmentText": "ACE is committed to continuously improving the quality of our coaching, training methods, and overall student experience. We listen to feedback so we can refine our programs, improve how classes are organized, and provide an increasingly professional training environment.",
        "about.commitmentTextTwo": "Whether your goal is to learn tennis from the beginning, improve your fitness, find a long-term sport, or prepare for competition, ACE Tennis Academy aims to be a place where you can confidently begin and continue your journey.",

        "about.finalTitle": "Start your journey with ACE",
        "about.finalText": "A racket, a tennis court, and a clear goal can be the beginning of a long journey. ACE Tennis Academy is ready to support you from your first shots to bigger milestones in the future.",

        "privacy.eyebrow": "INFORMATION", "privacy.title": "Privacy policy", "privacy.description": "Your information is used to support court bookings.", "privacy.heading": "Your privacy", "privacy.text": "We only use the information needed to confirm bookings and support customers.",
        "news.eyebrow": "NEWS", "news.indexTitle": "Latest news", "news.indexDescription": "Updates and stories from ACE.", "news.viewDetails": "View details", "news.readMore": "Read article", "news.latestLabel": "LATEST", "news.backToNews": "Back to news", "news.relatedTitle": "Related news", "news.tournamentTitle": "Tournaments", "news.tournamentDescription": "Updates on tournaments and competitions at ACE.", "news.tournamentCard": "ACE Community Cup", "news.tournamentText": "A friendly tournament for players of different levels.", "news.trainingTitle": "Training courts", "news.trainingDescription": "A quality training space for every session.", "news.trainingCard": "Competition-ready courts", "news.trainingText": "Our courts are maintained regularly for a consistent experience.", "news.promotionTitle": "Promotions", "news.promotionDescription": "New offers for ACE students and customers.", "news.promotionCard": "New student offer", "news.promotionText": "Book your first session and receive a tailored training consultation.",
        "admin.kicker": "ACE TENNIS ACADEMY", "admin.panel": "Management panel", "admin.dashboard": "Dashboard", "admin.dashboardTitle": "Dashboard", "admin.courts": "Courts", "admin.coaches": "Trainers", "admin.news": "News", "admin.logout": "Log out", "admin.loginTitle": "Admin login", "admin.loginDescription": "Sign in to manage your tennis academy.", "admin.email": "Email", "admin.password": "Password", "admin.login": "Sign in", "admin.loginInvalid": "The email or password is incorrect.", "admin.add": "Add new", "admin.edit": "Edit", "admin.delete": "Delete", "admin.save": "Save story", "admin.cancel": "Cancel", "admin.name": "Name", "admin.type": "Court type", "admin.price": "Price", "admin.description": "Description", "admin.experience": "Experience", "admin.imageUrl": "Image URL", "admin.certificates": "Certificates", "admin.achievements": "Achievements", "admin.introduction": "Introduction", "admin.titleVi": "Vietnamese title", "admin.titleEn": "English title", "admin.publishedAt": "Published at", "admin.shortContentVi": "Vietnamese short content", "admin.shortContentEn": "English short content", "admin.bannerImage": "Banner image", "admin.bannerHint": "JPG, PNG, WEBP or GIF, up to 5 MB.", "admin.bannerRequired": "Please select a banner image.", "admin.currentBanner": "Current banner", "admin.contentVi": "Vietnamese content", "admin.contentEn": "English content", "admin.newsKicker": "CONTENT STUDIO", "admin.newsForm": "Story details", "admin.newsFormDescription": "Create a clear, visual story for the ACE community.", "admin.draft": "DRAFT", "admin.storyBasics": "Story basics", "admin.storyBasicsHint": "Set the title and short preview shown on the news page.", "admin.visualDate": "Visual and date", "admin.visualDateHint": "Choose a banner that gives the story a strong first impression.", "admin.storyContent": "Story content", "admin.storyContentHint": "Format text, add links, lists, and images with the editor.", "admin.courtForm": "Court details", "admin.coachForm": "Trainer details", "admin.deleteConflict": "This item cannot be deleted because it is in use.", "admin.linkPrompt": "Enter link URL", "admin.imagePrompt": "Enter image URL"
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
    renderNewsContent();
    const menuToggle = document.querySelector(".navbar-toggler");
    if (menuToggle) menuToggle.setAttribute("aria-label", translations[currentLanguage]["nav.toggle"]);
    const languageLabel = document.querySelector("#languageDropdown");
    if (languageLabel) languageLabel.childNodes[0].textContent = currentLanguage === "vi" ? "VN" : "ENG";
    document.dispatchEvent(new CustomEvent("languageChanged", { detail: currentLanguage }));
};

const renderNewsContent = () => {
    document.querySelectorAll("[data-news-title-vi]").forEach((element) => {
        element.textContent = element.dataset[`newsTitle${currentLanguage === "vi" ? "Vi" : "En"}`];
    });
    document.querySelectorAll("[data-news-content-vi]").forEach((element) => {
        element.innerHTML = element.dataset[`newsContent${currentLanguage === "vi" ? "Vi" : "En"}`];
    });
};

window.translatePage = translatePage;
window.getTranslation = (key) => translations[currentLanguage][key] || key;

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
