function setupPrintReport(studentData) {
    document.querySelector('img[src*="print.png"]').addEventListener('click', function () {
        const printWindow = window.open('', '_blank', 'width=900,height=700');

        printWindow.document.write(`
            <!DOCTYPE html>
            <html>
            <head>
                <title>Student Registration Report</title>
                <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
                <img src="/images/header.jpg" alt="2مودرن " width="100%" height="70"><span class="fw-bolder">
                 <hr>
                <style>
                    body { padding: 25px; font-family: Arial; direction: rtl; }
                    .report-header { text-align: center; margin-bottom: 30px; }
                    .student-photo { 
                        width: 150px; height: 150px; 
                        object-fit: cover; border: 2px solid #ddd;
                        margin: 15px auto; display: block;
                    }
                    .report-table {
                        width: 100%; border-collapse: collapse;
                        margin: 25px 0; font-size: 14px;
                    }
                    .report-table th {
                        background-color: #f5f5f5;
                        padding: 10px; border: 1px solid #ddd;
                        width: 30%; text-align: right;
                    }
                    .report-table td {
                        padding: 10px; border: 1px solid #ddd;
                        text-align: right;
                    }
                    .english-text { direction: ltr; text-align: left; }
                    .signature-line {
                        width: 300px; border-bottom: 1px solid #000;
                        margin: 50px auto 15px;
                    }
                    @media print {
                        body { padding: 15px; }
                        .no-print { display: none !important; }
                    }
                </style>
            </head>
            <body>
                <div class="container">
                    <div class="report-header">
                        
                        ${studentData.profilePicture ? `<img src="${studentData.profilePicture}" class="student-photo">` : ''}
                    </div>
                    
                    <h5 class="text-center my-3">المعلومات الشخصية / Personal Information</h5>
                    <table class="report-table">
                        <tr><th>الاسم الكامل</th><td>${studentData.fullName || '-'}</td></tr>
                       
                        <tr><th>الرقم القومي</th><td>${studentData.studentId || '-'}</td></tr>
                       
                        <tr><th>تاريخ الميلاد</th><td>${studentData.birthDate || '-'}</td></tr>
                       
                        <tr><th>النوع</th><td>${studentData.gender === 'male' ? 'ذكر' : 'أنثى'}</td></tr>
                       
                        <tr><th>العنوان</th><td>${studentData.address || '-'}</td></tr>
                       
                        <tr><th>الجنسية</th><td>${studentData.nationality || '-'}</td></tr>
                       
                        <tr><th>الديانة</th><td>${studentData.religion || '-'}</td></tr>
                       
                    </table>

                    <h5 class="text-center my-3">معلومات ولي الأمر / Guardian Information</h5>
                    <table class="report-table">
                        <tr><th>اسم الأب</th><td>${studentData.fatherName || '-'}</td></tr>
                       
                        <tr><th>وظيفة الأب</th><td>${studentData.fatherJob || '-'}</td></tr>
                       
                        <tr><th>مؤهل الأب</th><td>${studentData.fatherCertificate || '-'}</td></tr>
                     
                        <tr><th>تليفون الأب</th><td>${studentData.fatherTelephone || '-'}</td></tr>
                      
                        <tr><th>رقم قومي الأب</th><td>${studentData.fatherId || '-'}</td></tr>
                    
                        <tr><th>اسم الأم</th><td>${studentData.motherName || '-'}</td></tr>
                 
                        <tr><th>وظيفة الأم</th><td>${studentData.motherJob || '-'}</td></tr>
                   
                        <tr><th>مؤهل الأم</th><td>${studentData.motherQualification || '-'}</td></tr>
                    
                        <tr><th>تليفون الأم</th><td>${studentData.motherTelephone || '-'}</td></tr>
                       
                        <tr><th>رقم قومي الأم</th><td>${studentData.motherNationalId || '-'}</td></tr>
                     
                    </table>

                    <h5 class="text-center my-3">المعلومات التعليمية / Academic Information</h5>
                    <table class="report-table">
                        <tr><th>المدرسة السابقة</th><td>${studentData.previousSchool || '-'}</td></tr>
                   
                        <tr><th>القسم</th><td>${studentData.studyLanguage || '-'}</td></tr>
                     
                        <tr><th>المرحلة</th><td>${studentData.educationalStage || '-'}</td></tr>
                  
                        <tr><th>الصف</th><td>${studentData.gradeLevel || '-'}</td></tr>
                    
                        <tr><th>الإدارة التعليمية</th><td>${studentData.governorate || '-'}</td></tr>
                       
                        <tr><th>اللغة الثانية</th><td>${studentData.secondLanguage || '-'}</td></tr>
                  
                    </table>

                    <h5 class="text-center my-3">الأشقاء / Siblings</h5>
                    <table class="report-table">
                        <tr><th>الأخ/الأخت الأول</th><td>${studentData.firstSiblingName || '-'}</td></tr>
                   
                        <tr><th>الصف</th><td>${studentData.firstSiblingGrade || '-'}</td></tr>
                 
                        <tr><th>الأخ/الأخت الثاني</th><td>${studentData.secondSiblingName || '-'}</td></tr>
                   
                        <tr><th>الصف</th><td>${studentData.secondSiblingGrade || '-'}</td></tr>
                   
                        <tr><th>الأخ/الأخت الثالث</th><td>${studentData.thirdSiblingName || '-'}</td></tr>
                   
                        <tr><th>الصف</th><td>${studentData.thirdSiblingGrade || '-'}</td></tr>
                     
                    </table>

                    <div class="text-center">
                        <div class="signature-line"></div>
                        <p>ختم المدرسة / School Stamp</p>
                        
                    </div>
                </div>
                
                <div class="no-print text-center mt-3">
                    <button onclick="window.close()" class="btn btn-sm btn-danger">إغلاق / Close Window</button>
                </div>
                
                <script>
                    window.onload = function() {
                        setTimeout(function() {
                            window.print();
                        }, 300);
                    };
                </script>
            </body>
            </html>
        `);
        printWindow.document.close();
    });
}