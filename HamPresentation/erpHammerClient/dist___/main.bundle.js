webpackJsonp(["main"],{

/***/ "./src/$$_gendir lazy recursive":
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncatched exception popping up in devtools
	return Promise.resolve().then(function() {
		throw new Error("Cannot find module '" + req + "'.");
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_gendir lazy recursive";

/***/ }),

/***/ "./src/app/app.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"layout-wrapper\" [ngClass]=\"{'layout-compact':layoutCompact}\">\r\n    <div #layoutContainer class=\"layout-container\"\r\n         [ngClass]=\"{'menu-layout-static': !isOverlay(),\r\n            'menu-layout-overlay': isOverlay(),\r\n            'layout-menu-overlay-active': overlayMenuActive,\r\n            'menu-layout-horizontal': isHorizontal(),\r\n            'layout-menu-static-inactive': staticMenuDesktopInactive,\r\n            'layout-menu-static-active': staticMenuMobileActive}\">\r\n        <div #layoutMenuScroller class=\"nano\">\r\n            <div class=\"nano-content menu-scroll-content\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<router-outlet></router-outlet>\r\n"

/***/ }),

/***/ "./src/app/app.component.scss":
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/app.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var MenuOrientation;
(function (MenuOrientation) {
    MenuOrientation[MenuOrientation["STATIC"] = 0] = "STATIC";
    MenuOrientation[MenuOrientation["OVERLAY"] = 1] = "OVERLAY";
    MenuOrientation[MenuOrientation["HORIZONTAL"] = 2] = "HORIZONTAL";
})(MenuOrientation || (MenuOrientation = {}));
;
var AppComponent = /** @class */ (function () {
    function AppComponent(renderer) {
        this.renderer = renderer;
        this.layoutCompact = false;
        this.layoutMode = MenuOrientation.STATIC;
        this.darkMenu = false;
        this.profileMode = 'inline';
    }
    AppComponent.prototype.ngAfterViewInit = function () {
        var _this = this;
        this.layoutContainer = this.layourContainerViewChild.nativeElement;
        this.layoutMenuScroller = this.layoutMenuScrollerViewChild.nativeElement;
        // hides the horizontal submenus or top menu if outside is clicked
        this.documentClickListener = this.renderer.listenGlobal('body', 'click', function (event) {
            if (!_this.topbarItemClick) {
                _this.activeTopbarItem = null;
                _this.topbarMenuActive = false;
            }
            if (!_this.menuClick && _this.isHorizontal()) {
                _this.resetMenu = true;
            }
            _this.topbarItemClick = false;
            _this.menuClick = false;
        });
        setTimeout(function () {
            jQuery(_this.layoutMenuScroller).nanoScroller({ flash: true });
        }, 10);
    };
    AppComponent.prototype.onMenuButtonClick = function (event) {
        this.rotateMenuButton = !this.rotateMenuButton;
        this.topbarMenuActive = false;
        if (this.layoutMode === MenuOrientation.OVERLAY) {
            this.overlayMenuActive = !this.overlayMenuActive;
        }
        else {
            if (this.isDesktop()) {
                this.staticMenuDesktopInactive = !this.staticMenuDesktopInactive;
            }
            else {
                this.staticMenuMobileActive = !this.staticMenuMobileActive;
            }
        }
        event.preventDefault();
    };
    AppComponent.prototype.onMenuClick = function ($event) {
        var _this = this;
        this.menuClick = true;
        this.resetMenu = false;
        if (!this.isHorizontal()) {
            setTimeout(function () {
                jQuery(_this.layoutMenuScroller).nanoScroller();
            }, 500);
        }
    };
    AppComponent.prototype.onTopbarMenuButtonClick = function (event) {
        this.topbarItemClick = true;
        this.topbarMenuActive = !this.topbarMenuActive;
        if (this.overlayMenuActive || this.staticMenuMobileActive) {
            this.rotateMenuButton = false;
            this.overlayMenuActive = false;
            this.staticMenuMobileActive = false;
        }
        event.preventDefault();
    };
    AppComponent.prototype.onTopbarItemClick = function (event, item) {
        this.topbarItemClick = true;
        if (this.activeTopbarItem === item) {
            this.activeTopbarItem = null;
        }
        else {
            this.activeTopbarItem = item;
        }
        event.preventDefault();
    };
    AppComponent.prototype.isTablet = function () {
        var width = window.innerWidth;
        return width <= 1024 && width > 640;
    };
    AppComponent.prototype.isDesktop = function () {
        return window.innerWidth > 1024;
    };
    AppComponent.prototype.isMobile = function () {
        return window.innerWidth <= 640;
    };
    AppComponent.prototype.isOverlay = function () {
        return this.layoutMode === MenuOrientation.OVERLAY;
    };
    AppComponent.prototype.isHorizontal = function () {
        return this.layoutMode === MenuOrientation.HORIZONTAL;
    };
    AppComponent.prototype.changeToStaticMenu = function () {
        this.layoutMode = MenuOrientation.STATIC;
    };
    AppComponent.prototype.changeToOverlayMenu = function () {
        this.layoutMode = MenuOrientation.OVERLAY;
    };
    AppComponent.prototype.changeToHorizontalMenu = function () {
        this.layoutMode = MenuOrientation.HORIZONTAL;
    };
    AppComponent.prototype.ngOnDestroy = function () {
        if (this.documentClickListener) {
            this.documentClickListener();
        }
        jQuery(this.layoutMenuScroller).nanoScroller({ flash: true });
    };
    var _a, _b, _c;
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])('layoutContainer'),
        __metadata("design:type", typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"]) === "function" && _a || Object)
    ], AppComponent.prototype, "layourContainerViewChild", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])('layoutMenuScroller'),
        __metadata("design:type", typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"]) === "function" && _b || Object)
    ], AppComponent.prototype, "layoutMenuScrollerViewChild", void 0);
    AppComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-root',
            template: __webpack_require__("./src/app/app.component.html"),
            styles: [__webpack_require__("./src/app/app.component.scss")]
        }),
        __metadata("design:paramtypes", [typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["Renderer"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_0__angular_core__["Renderer"]) === "function" && _c || Object])
    ], AppComponent);
    return AppComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/app.component.js.map

/***/ }),

/***/ "./src/app/app.footer.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppFooter; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppFooter = /** @class */ (function () {
    // tslint:disable-next-line:component-class-suffix
    function AppFooter() {
    }
    AppFooter = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-footer',
            template: "\n       \n        <p-toolbar>\n\n        <div class=\"ui-g-3\"> <img src=\"../../../../../assets/erpHammer/images/hammerLogoH.png\"  style=\"width: 150px; height: 25px\"/></div>\n        \n        <div class=\"ui-toolbar-group-right\"> <span style=\"color: #fff;\">All Rights Reserved</span>\n        <button pButton type=\"button\" icon=\"ui-icon-verified-user\"></button>\n        <i class=\"fa fa-bars\"></i>\n    </div>\n        </p-toolbar>\n    "
        })
        // tslint:disable-next-line:component-class-suffix
    ], AppFooter);
    return AppFooter;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/app.footer.component.js.map

/***/ }),

/***/ "./src/app/app.menu.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppMenuComponent; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return AppSubMenu; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_animations__ = __webpack_require__("./node_modules/@angular/animations/@angular/animations.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_common__ = __webpack_require__("./node_modules/@angular/common/@angular/common.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_router__ = __webpack_require__("./node_modules/@angular/router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_primeng_primeng__ = __webpack_require__("./node_modules/primeng/primeng.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_primeng_primeng___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4_primeng_primeng__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__app_component__ = __webpack_require__("./src/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__site_service_Shared_usuario_service__ = __webpack_require__("./src/app/site/service/Shared/usuario.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7_rxjs_Rx__ = __webpack_require__("./node_modules/rxjs/_esm5/Rx.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};








var AppMenuComponent = /** @class */ (function () {
    function AppMenuComponent(app, usuarioService) {
        this.app = app;
        this.usuarioService = usuarioService;
    }
    AppMenuComponent.prototype.ngOnInit = function () {
        var _this = this;
        var item_copia = [];
        var usuario = JSON.parse(sessionStorage.getItem("resu"));
        this.changeTheme("grey");
        this.usuarioService.getToc(usuario.UserId).subscribe(function (res) {
            _this.listaMenu = res;
            _this.listaMenu = JSON.parse(_this.listaMenu);
            _this.model = _this.listaMenu;
        });
    };
    AppMenuComponent.prototype.changeTheme = function (theme) {
        var themeLink = document.getElementById("theme-css");
        var layoutLink = document.getElementById("layout-css");
        themeLink.href = "assets/theme/theme-" + theme + ".css";
        layoutLink.href = "assets/layout/css/layout-" + theme + ".css";
    };
    var _a, _b;
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Boolean)
    ], AppMenuComponent.prototype, "reset", void 0);
    AppMenuComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: "app-menu",
            template: "\n        <ul app-submenu [item]=\"model\" root=\"true\" class=\"ultima-menu ultima-main-menu clearfix\" [reset]=\"reset\" visible=\"true\"></ul>\n    ",
            providers: [__WEBPACK_IMPORTED_MODULE_6__site_service_Shared_usuario_service__["a" /* UsuarioService */]]
        }),
        __param(0, Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Inject"])(Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["forwardRef"])(function () { return __WEBPACK_IMPORTED_MODULE_5__app_component__["a" /* AppComponent */]; }))),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_5__app_component__["a" /* AppComponent */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_5__app_component__["a" /* AppComponent */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_6__site_service_Shared_usuario_service__["a" /* UsuarioService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_6__site_service_Shared_usuario_service__["a" /* UsuarioService */]) === "function" && _b || Object])
    ], AppMenuComponent);
    return AppMenuComponent;
}());

var AppSubMenu = /** @class */ (function () {
    function AppSubMenu(app, router, location) {
        this.app = app;
        this.router = router;
        this.location = location;
    }
    AppSubMenu.prototype.itemClick = function (event, item, index) {
        /*avoid processing disabled items*/
        if (item.disabled) {
            event.preventDefault();
            return true;
        }
        /*activate current item and deactivate active sibling if any*/
        this.activeIndex = this.activeIndex === index ? null : index;
        /*execute command*/
        if (item.command) {
            item.command({
                originalEvent: event,
                item: item
            });
        }
        /*prevent hash change*/
        if (item.items || (!item.url && !item.routerLink)) {
            event.preventDefault();
        }
        /*hide menu*/
        if (!item.items) {
            if (this.app.isHorizontal()) {
                this.app.resetMenu = true;
            }
            else {
                this.app.resetMenu = false;
            }
            this.app.overlayMenuActive = false;
            this.app.staticMenuMobileActive = false;
        }
    };
    AppSubMenu.prototype.isActive = function (index) {
        return this.activeIndex === index;
    };
    Object.defineProperty(AppSubMenu.prototype, "reset", {
        get: function () {
            return this._reset;
        },
        set: function (val) {
            this._reset = val;
            if (this._reset && this.app.isHorizontal()) {
                this.activeIndex = null;
            }
        },
        enumerable: true,
        configurable: true
    });
    var _c, _d, _e, _f;
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_4_primeng_primeng__["MenuItem"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_4_primeng_primeng__["MenuItem"]) === "function" && _c || Object)
    ], AppSubMenu.prototype, "item", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Boolean)
    ], AppSubMenu.prototype, "root", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Boolean)
    ], AppSubMenu.prototype, "visible", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Boolean),
        __metadata("design:paramtypes", [Boolean])
    ], AppSubMenu.prototype, "reset", null);
    AppSubMenu = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: "[app-submenu]",
            template: "\n        <ng-template ngFor let-child let-i=\"index\" [ngForOf]=\"(root ? item : item.items)\">\n            <li [ngClass]=\"{'active-menuitem': isActive(i)}\" *ngIf=\"child.visible === false ? false : true\">\n                <a [href]=\"child.url||'#'\" (click)=\"itemClick($event,child,i)\" \n                class=\"ripplelink\" *ngIf=\"!child.routerLink\" [attr.tabindex]=\"!visible ? '-1' : null\" [attr.target]=\"child.target\">\n                    <i class=\"material-icons\">{{child.icon}}</i>\n                    <span>{{child.label}}</span>\n                    <i class=\"material-icons\" *ngIf=\"child.items\">keyboard_arrow_down</i>\n                </a>\n                <a (click)=\"itemClick($event,child,i)\" class=\"ripplelink\" *ngIf=\"child.routerLink\"\n                    [routerLink]=\"child.routerLink\" routerLinkActive=\"active-menuitem-routerlink\" \n                    [routerLinkActiveOptions]=\"{exact: true}\" [attr.tabindex]=\"!visible ? '-1' : null\" [attr.target]=\"child.target\">\n                    <i class=\"material-icons\">{{child.icon}}</i>\n                    <span>{{child.label}}</span>\n                    <i class=\"material-icons\" *ngIf=\"child.items\">keyboard_arrow_down</i>\n                </a>\n                <ul app-submenu [item]=\"child\" *ngIf=\"child.items\" [@children]=\"isActive(i) ? 'visible' : 'hidden'\" \n                [visible]=\"isActive(i)\" [reset]=\"reset\"></ul>\n            </li>\n        </ng-template>\n    ",
            animations: [
                Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["trigger"])("children", [
                    Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["state"])("hidden", Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["style"])({
                        height: "0px"
                    })),
                    Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["state"])("visible", Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["style"])({
                        height: "*"
                    })),
                    Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["transition"])("visible => hidden", Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["animate"])("400ms cubic-bezier(0.86, 0, 0.07, 1)")),
                    Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["transition"])("hidden => visible", Object(__WEBPACK_IMPORTED_MODULE_1__angular_animations__["animate"])("400ms cubic-bezier(0.86, 0, 0.07, 1)"))
                ])
            ]
        })
        // tslint:disable-next-line:component-class-suffix
        ,
        __param(0, Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Inject"])(Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["forwardRef"])(function () { return __WEBPACK_IMPORTED_MODULE_5__app_component__["a" /* AppComponent */]; }))),
        __metadata("design:paramtypes", [typeof (_d = typeof __WEBPACK_IMPORTED_MODULE_5__app_component__["a" /* AppComponent */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_5__app_component__["a" /* AppComponent */]) === "function" && _d || Object, typeof (_e = typeof __WEBPACK_IMPORTED_MODULE_3__angular_router__["Router"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_3__angular_router__["Router"]) === "function" && _e || Object, typeof (_f = typeof __WEBPACK_IMPORTED_MODULE_2__angular_common__["Location"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__angular_common__["Location"]) === "function" && _f || Object])
    ], AppSubMenu);
    return AppSubMenu;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/app.menu.component.js.map

/***/ }),

/***/ "./src/app/app.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export createConfig */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_forms__ = __webpack_require__("./node_modules/@angular/forms/@angular/forms.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_http__ = __webpack_require__("./node_modules/@angular/http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_platform_browser__ = __webpack_require__("./node_modules/@angular/platform-browser/@angular/platform-browser.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_platform_browser_animations__ = __webpack_require__("./node_modules/@angular/platform-browser/@angular/platform-browser/animations.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__angular_common__ = __webpack_require__("./node_modules/@angular/common/@angular/common.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__app_routes__ = __webpack_require__("./src/app/app.routes.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7_ng2_signalr__ = __webpack_require__("./node_modules/ng2-signalr/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__ngui_auto_complete__ = __webpack_require__("./node_modules/@ngui/auto-complete/dist/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__ngui_auto_complete___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_8__ngui_auto_complete__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9_rxjs_add_operator_toPromise__ = __webpack_require__("./node_modules/rxjs/_esm5/add/operator/toPromise.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9_rxjs_add_operator_toPromise___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_9_rxjs_add_operator_toPromise__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__ = __webpack_require__("./node_modules/primeng/primeng.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10_primeng_primeng___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_10_primeng_primeng__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__app_component__ = __webpack_require__("./src/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__app_menu_component__ = __webpack_require__("./src/app/app.menu.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__site_view_components_topbar_tabbar_component__ = __webpack_require__("./src/app/site/view/components/topbar/tabbar.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14__app_footer_component__ = __webpack_require__("./src/app/app.footer.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__app_profile_component__ = __webpack_require__("./src/app/app.profile.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_16__site_shared_auth_guard__ = __webpack_require__("./src/app/site/shared/auth.guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_17__site_view_components_login_login_component__ = __webpack_require__("./src/app/site/view/components/login/login.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_18__site_view_components_mastePage_master_page_component__ = __webpack_require__("./src/app/site/view/components/mastePage/master-page.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_19__site_view_components_multimedia_webcam_webcam_component__ = __webpack_require__("./src/app/site/view/components/multimedia/webcam/webcam.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_20__site_view_Administracion_usuario_user_pass_user_pass_component__ = __webpack_require__("./src/app/site/view/Administracion/usuario/user-pass/user-pass.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_21__site_view_Denuncias_vw_formulario_vw_formulario_component__ = __webpack_require__("./src/app/site/view/Denuncias/vw-formulario/vw-formulario.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_22__site_view_Denuncias_vw_listados_vw_listados_component__ = __webpack_require__("./src/app/site/view/Denuncias/vw-listados/vw-listados.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_23__site_component_dropdown_drop_parametros_drop_parametros_component__ = __webpack_require__("./src/app/site/component/dropdown/drop-parametros/drop-parametros.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_24__site_component_dropdown_drop_zonificacion_drop_zonificacion_component__ = __webpack_require__("./src/app/site/component/dropdown/drop-zonificacion/drop-zonificacion.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_25__site_component_dropdown_drop_offices_drop_offices_component__ = __webpack_require__("./src/app/site/component/dropdown/drop-offices/drop-offices.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



















































































// import { UsuarioListadoComponent } from './site/view/Administracion/usuario/usuario-listado/usuario-listado.component';
// import { DetalleUsuarioComponent } from './site/view/Administracion/usuario/usuario-detalle/usuario-detalle.component';
// import { UsuarioPrivilegiosComponent } from './site/view/Administracion/usuario/usuario-privilegios/usuario-privilegios.component';
// import { StepsComponent } from './site/view/components/steps/steps.component';
// tslint:disable-next-line:max-line-length


// import { CronogramaConjuntoComponent } from './site/component/grilla/cronograma-conjunto/cronograma-conjunto.component';
// import { DeportesComponent } from './site/component/dropdown/deportes/deportes.component';
// import { UsuarioRegistroComponent } from './site/view/Administracion/usuario/usuario-registro/usuario-registro.component';
// import { AutocompleteComponent } from './site/component/searchpersona/autocomplete/autocomplete.component';
// import { DialogoConjuntoComponent } from './site/component/dialogo/dialogo-conjunto/dialogo-conjunto.component';
// import { BotonConjuntoComponent } from './site/component/boton/boton-conjunto/boton-conjunto.component';
// import { BuscarPersonaComponent } from './site/component/searchpersona/buscar-persona/buscar-persona.component';
// import { DialogoCompetidorComponent } from './site/component/dialogo-competidor/dialogo-competidor.component';
// tslint:disable-next-line:max-line-length
// import { PmenuComponent } from './site/view/pmenu/pmenu.component';





function createConfig() {
    var c = new __WEBPACK_IMPORTED_MODULE_7_ng2_signalr__["a" /* SignalRConfiguration */]();
    c.hubName = 'testHub';
    c.qs = { name: 'donald' };
    c.url = 'http://localhost:61428';
    c.logging = true;
    return c;
}
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_3__angular_platform_browser__["BrowserModule"],
                __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormsModule"],
                __WEBPACK_IMPORTED_MODULE_1__angular_forms__["ReactiveFormsModule"],
                __WEBPACK_IMPORTED_MODULE_6__app_routes__["a" /* AppRoutes */],
                __WEBPACK_IMPORTED_MODULE_2__angular_http__["HttpModule"],
                __WEBPACK_IMPORTED_MODULE_7_ng2_signalr__["b" /* SignalRModule */].forRoot(createConfig),
                __WEBPACK_IMPORTED_MODULE_4__angular_platform_browser_animations__["a" /* BrowserAnimationsModule */],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["AccordionModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["AutoCompleteModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["BreadcrumbModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ButtonModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["CalendarModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["CarouselModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ChartModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["CheckboxModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ChipsModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["CodeHighlighterModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ConfirmDialogModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["SharedModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ContextMenuModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["DataGridModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["DataListModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["DataScrollerModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["DataTableModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["DialogModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["DragDropModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["DropdownModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["EditorModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["FieldsetModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["FileUploadModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["GalleriaModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["GMapModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["GrowlModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["InputMaskModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["InputSwitchModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["InputTextModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["InputTextareaModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["LightboxModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ListboxModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["MegaMenuModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["MenuModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["MenubarModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["MessagesModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["MultiSelectModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["OrderListModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["OverlayPanelModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["PaginatorModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["PanelModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["PanelMenuModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["PasswordModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["PickListModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ProgressBarModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["RadioButtonModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["RatingModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ScheduleModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["SelectButtonModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["SlideMenuModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["SliderModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["SpinnerModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["SplitButtonModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["StepsModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["TabMenuModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["TabViewModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["TerminalModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["TieredMenuModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ToggleButtonModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["ToolbarModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["TooltipModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["TreeModule"],
                __WEBPACK_IMPORTED_MODULE_10_primeng_primeng__["TreeTableModule"],
                __WEBPACK_IMPORTED_MODULE_8__ngui_auto_complete__["NguiAutoCompleteModule"]
            ],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_11__app_component__["a" /* AppComponent */],
                __WEBPACK_IMPORTED_MODULE_12__app_menu_component__["a" /* AppMenuComponent */],
                __WEBPACK_IMPORTED_MODULE_12__app_menu_component__["b" /* AppSubMenu */],
                __WEBPACK_IMPORTED_MODULE_13__site_view_components_topbar_tabbar_component__["a" /* AppTopBar */],
                __WEBPACK_IMPORTED_MODULE_14__app_footer_component__["a" /* AppFooter */],
                __WEBPACK_IMPORTED_MODULE_15__app_profile_component__["a" /* InlineProfileComponent */],
                __WEBPACK_IMPORTED_MODULE_17__site_view_components_login_login_component__["a" /* Login */],
                __WEBPACK_IMPORTED_MODULE_18__site_view_components_mastePage_master_page_component__["a" /* MasterPage */],
                // StepsComponent,
                __WEBPACK_IMPORTED_MODULE_19__site_view_components_multimedia_webcam_webcam_component__["a" /* WebcamComponent */],
                // UsuarioListadoComponent,
                // DetalleUsuarioComponent,
                // UsuarioPrivilegiosComponent,
                __WEBPACK_IMPORTED_MODULE_20__site_view_Administracion_usuario_user_pass_user_pass_component__["a" /* UserPassComponent */],
                // UsuarioRegistroComponent,
                // AutocompleteComponent,
                // DialogoConjuntoComponent,
                // BotonConjuntoComponent,
                // CronogramaConjuntoComponent,
                // DeportesComponent,
                // BuscarPersonaComponent,
                // PmenuComponent,
                __WEBPACK_IMPORTED_MODULE_21__site_view_Denuncias_vw_formulario_vw_formulario_component__["a" /* VwFormularioComponent */],
                __WEBPACK_IMPORTED_MODULE_22__site_view_Denuncias_vw_listados_vw_listados_component__["a" /* VwListadosComponent */],
                __WEBPACK_IMPORTED_MODULE_23__site_component_dropdown_drop_parametros_drop_parametros_component__["a" /* DropParametrosComponent */],
                __WEBPACK_IMPORTED_MODULE_24__site_component_dropdown_drop_zonificacion_drop_zonificacion_component__["a" /* DropZonificacionComponent */],
                __WEBPACK_IMPORTED_MODULE_25__site_component_dropdown_drop_offices_drop_offices_component__["a" /* DropOfficesComponent */]
            ],
            providers: [
                { provide: __WEBPACK_IMPORTED_MODULE_5__angular_common__["LocationStrategy"], useClass: __WEBPACK_IMPORTED_MODULE_5__angular_common__["HashLocationStrategy"] },
                __WEBPACK_IMPORTED_MODULE_16__site_shared_auth_guard__["a" /* AuthGuard */]
            ],
            bootstrap: [__WEBPACK_IMPORTED_MODULE_11__app_component__["a" /* AppComponent */]]
        })
    ], AppModule);
    return AppModule;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/app.module.js.map

/***/ }),

/***/ "./src/app/app.profile.component.css":
/***/ (function(module, exports) {

module.exports = ".fotoPerfil {\r\n    width: 60px;\r\n    height: 60px;\r\n    margin: 0 auto 5px auto;\r\n    background-size: 60px 60px;\r\n    border-radius: 50%;\r\n}\r\n"

/***/ }),

/***/ "./src/app/app.profile.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return InlineProfileComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("./node_modules/@angular/router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__site_service_Shared_usuario_service__ = __webpack_require__("./src/app/site/service/Shared/usuario.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var InlineProfileComponent = /** @class */ (function () {
    function InlineProfileComponent(router, usuarioService) {
        this.router = router;
        this.usuarioService = usuarioService;
    }
    InlineProfileComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.foto = 'data:image/gif;base64,R0lGODlhAQABAIAAAAUEBAAAACwAAAAAAQABAAACAkQBADs=';
        this.usuario = JSON.parse(sessionStorage.getItem('resu'));
        this.usuarioService.getFotoPerfil(this.usuario.UserId)
            .then(function (res) {
            _this.foto = res;
        });
    };
    InlineProfileComponent.prototype.closeLoggin = function () {
        sessionStorage.setItem('resu', '');
        this.router.navigate(['/login']);
        return false;
    };
    InlineProfileComponent.prototype.onClick = function (event) {
        this.active = !this.active;
        event.preventDefault();
    };
    var _a, _b;
    InlineProfileComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'inline-profile',
            template: "\n        <div class=\"profile\" [ngClass]=\"{'profile-expanded':active}\">\n                <div class=\"fotoPerfil\" [ngStyle]=\"{'background-image':'url(' + foto + ')'}\"></div>\n            <a href=\"#\" (click)=\"onClick($event)\">\n                <span class=\"profile-name\">{{usuario.Username}}</span>\n                <i class=\"material-icons\">keyboard_arrow_down</i>\n            </a>\n        </div>\n\n        <ul class=\"ultima-menu profile-menu\" [@menu]=\"active ? 'visible' : 'hidden'\">\n            <li role=\"menuitem\">\n                <a href=\"#\" (click)=\"closeLoggin()\" class=\"ripplelink\" [attr.tabindex]=\"!active ? '-1' : null\">\n                    <i class=\"material-icons\">power_settings_new</i>\n                    <span>Cerrar Sesi&oacute;n</span>\n                </a>\n            </li>\n            <li role=\"menuitem\">\n                <a href=\"#/master/repass/1\"  class=\"ripplelink\" [attr.tabindex]=\"!active ? '-1' : null\">\n                    <i class=\"material-icons\">lock</i>\n                    <span>Cambiar Contrase\u00F1a</span>\n                </a>\n            </li>\n        </ul>\n    ",
            animations: [
                Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["trigger"])('menu', [
                    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["state"])('hidden', Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["style"])({
                        height: '0px'
                    })),
                    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["state"])('visible', Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["style"])({
                        height: '*'
                    })),
                    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["transition"])('visible => hidden', Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["animate"])('400ms cubic-bezier(0.86, 0, 0.07, 1)')),
                    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["transition"])('hidden => visible', Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["animate"])('400ms cubic-bezier(0.86, 0, 0.07, 1)'))
                ])
            ],
            providers: [__WEBPACK_IMPORTED_MODULE_2__site_service_Shared_usuario_service__["a" /* UsuarioService */]],
            styles: [__webpack_require__("./src/app/app.profile.component.css")]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_2__site_service_Shared_usuario_service__["a" /* UsuarioService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__site_service_Shared_usuario_service__["a" /* UsuarioService */]) === "function" && _b || Object])
    ], InlineProfileComponent);
    return InlineProfileComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/app.profile.component.js.map

/***/ }),

/***/ "./src/app/app.routes.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export routes */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppRoutes; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("./node_modules/@angular/router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__site_view_components_login_login_component__ = __webpack_require__("./src/app/site/view/components/login/login.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__site_view_components_mastePage_master_page_routes__ = __webpack_require__("./src/app/site/view/components/mastePage/master-page.routes.ts");


// tslint:disable-next-line:max-line-length

// import { UsersListComponent } from './site/view/Administracion/usuario/users-list/users-list.component';
// import { PmenuComponent } from './site/view/pmenu/pmenu.component';
// tslint:disable-next-line:max-line-length
// import { CronogramaConjuntoComponent } from './site/component/grilla/cronograma-conjunto/cronograma-conjunto.component';
var routes = __WEBPACK_IMPORTED_MODULE_2__site_view_components_mastePage_master_page_routes__["a" /* MasterRoutes */].concat([
    { path: 'login', component: __WEBPACK_IMPORTED_MODULE_1__site_view_components_login_login_component__["a" /* Login */] },
]);
var AppRoutes = __WEBPACK_IMPORTED_MODULE_0__angular_router__["RouterModule"].forRoot(routes);
//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/app.routes.js.map

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-offices/drop-offices.component.css":
/***/ (function(module, exports) {

module.exports = " \r\n#ladiv\r\n{\r\n    color: #999;\r\n    font-size: 12px;\r\n    left: 5px;\r\n    margin-top: -20px;\r\n}"

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-offices/drop-offices.component.html":
/***/ (function(module, exports) {

module.exports = "<div id=\"ladiv\">{{this.LabelText}}:</div>       \n<p-dropdown [options]=\"offices\"  placeholder=\"Seleccione {{this.LabelText}}\"  optionLabel=\"Name\" [disabled]=\"disable\"\n [style]=\"{'width':'250px'}\" (onChange)=\"onChangeParameter($event)\" [filter]=\"Filter\"></p-dropdown> "

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-offices/drop-offices.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DropOfficesComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_site_service_Shared_parametro_service__ = __webpack_require__("./src/app/site/service/Shared/parametro.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var DropOfficesComponent = /** @class */ (function () {
    function DropOfficesComponent(parametroService) {
        this.parametroService = parametroService;
        this.LabelText = "Seleccione una Opcion";
        this.disable = false;
        this.Filter = false;
        this.office = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["EventEmitter"]();
    }
    DropOfficesComponent.prototype.ngOnInit = function () {
        this.doGetOffices();
    };
    DropOfficesComponent.prototype.ngOnChanges = function (change) {
        this.doGetOffices();
    };
    DropOfficesComponent.prototype.doGetOffices = function () {
        var _this = this;
        this.parametroService.getOffices(this.Level, this.dependentId)
            .then(function (res) {
            _this.offices = res;
            // console.log(this.zoning);
        });
    };
    DropOfficesComponent.prototype.onChangeParameter = function ($event) {
        this.office.emit($event.value);
    };
    var _a;
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Number)
    ], DropOfficesComponent.prototype, "Level", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Number)
    ], DropOfficesComponent.prototype, "dependentId", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropOfficesComponent.prototype, "LabelText", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropOfficesComponent.prototype, "disable", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropOfficesComponent.prototype, "Filter", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Output"])(),
        __metadata("design:type", Object)
    ], DropOfficesComponent.prototype, "office", void 0);
    DropOfficesComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-drop-offices',
            template: __webpack_require__("./src/app/site/component/dropdown/drop-offices/drop-offices.component.html"),
            styles: [__webpack_require__("./src/app/site/component/dropdown/drop-offices/drop-offices.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_1_app_site_service_Shared_parametro_service__["a" /* ParametroService */]]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1_app_site_service_Shared_parametro_service__["a" /* ParametroService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1_app_site_service_Shared_parametro_service__["a" /* ParametroService */]) === "function" && _a || Object])
    ], DropOfficesComponent);
    return DropOfficesComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/drop-offices.component.js.map

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-parametros/drop-parametros.component.css":
/***/ (function(module, exports) {

module.exports = " \r\n#ladiv\r\n{\r\n    color: #999;\r\n    font-size: 12px;\r\n    left: 5px;\r\n    margin-top: -20px;\r\n}"

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-parametros/drop-parametros.component.html":
/***/ (function(module, exports) {

module.exports = "<div id=\"ladiv\">{{this.LabelText}}:</div>       \n<p-dropdown [options]=\"parameters\"  placeholder=\"Seleccione {{this.LabelText}}\"  optionLabel=\"Parameter\" [disabled]=\"disable\"\n [style]=\"{'width':'150px'}\" (onChange)=\"onChangeParameter($event)\" [filter]=\"Filter\"></p-dropdown> \n "

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-parametros/drop-parametros.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DropParametrosComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__service_Shared_parametro_service__ = __webpack_require__("./src/app/site/service/Shared/parametro.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var DropParametrosComponent = /** @class */ (function () {
    function DropParametrosComponent(parametroService) {
        this.parametroService = parametroService;
        this.GroupId = 0;
        this.disable = false;
        this.LabelText = "Seleccione una Opcion";
        this.Filter = false;
        this.Parameter = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["EventEmitter"]();
    }
    DropParametrosComponent.prototype.ngOnInit = function () {
        this.doGetParameters();
    };
    DropParametrosComponent.prototype.doGetParameters = function () {
        var _this = this;
        this.parametroService.getParametro(this.GroupId)
            .then(function (res) {
            _this.parameters = res;
        });
    };
    DropParametrosComponent.prototype.onChangeParameter = function ($event) {
        this.Parameter.emit($event.value);
    };
    var _a;
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropParametrosComponent.prototype, "GroupId", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropParametrosComponent.prototype, "disable", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropParametrosComponent.prototype, "LabelText", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropParametrosComponent.prototype, "Filter", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Output"])(),
        __metadata("design:type", Object)
    ], DropParametrosComponent.prototype, "Parameter", void 0);
    DropParametrosComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-drop-parametros',
            template: __webpack_require__("./src/app/site/component/dropdown/drop-parametros/drop-parametros.component.html"),
            styles: [__webpack_require__("./src/app/site/component/dropdown/drop-parametros/drop-parametros.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_1__service_Shared_parametro_service__["a" /* ParametroService */]]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__service_Shared_parametro_service__["a" /* ParametroService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__service_Shared_parametro_service__["a" /* ParametroService */]) === "function" && _a || Object])
    ], DropParametrosComponent);
    return DropParametrosComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/drop-parametros.component.js.map

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-zonificacion/drop-zonificacion.component.css":
/***/ (function(module, exports) {

module.exports = "#ladiv\r\n{\r\n    color: #999;\r\n    font-size: 12px;\r\n    left: 5px;\r\n    margin-top: -20px;\r\n}"

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-zonificacion/drop-zonificacion.component.html":
/***/ (function(module, exports) {

module.exports = "<div id=\"ladiv\">{{this.LabelText}}: </div>     \n<p-dropdown [options]=\"zoning\"  placeholder=\"Seleccione {{this.LabelText}}\"  optionLabel=\"Description\" [style]=\"{'width':'250px'}\" (onChange)=\"onChangeZoning($event)\" filter=\"filter\" [disabled]=\"disable\"></p-dropdown> \n "

/***/ }),

/***/ "./src/app/site/component/dropdown/drop-zonificacion/drop-zonificacion.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DropZonificacionComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_site_service_Shared_parametro_service__ = __webpack_require__("./src/app/site/service/Shared/parametro.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var DropZonificacionComponent = /** @class */ (function () {
    function DropZonificacionComponent(parametroService) {
        this.parametroService = parametroService;
        this.LabelText = "Seleccione una Opcion";
        this.disable = false;
        this.zone = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["EventEmitter"]();
    }
    DropZonificacionComponent.prototype.ngOnInit = function () {
        //  this.doGetZoning();
    };
    DropZonificacionComponent.prototype.ngOnChanges = function (changes) {
        this.doGetZoning();
    };
    DropZonificacionComponent.prototype.doGetZoning = function () {
        var _this = this;
        this.parametroService.getZoning(this.Level, this.dependentId)
            .then(function (res) {
            _this.zoning = res;
            console.log(_this.zoning);
        });
    };
    DropZonificacionComponent.prototype.onChangeZoning = function ($event) {
        this.zone.emit($event.value);
    };
    var _a;
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Number)
    ], DropZonificacionComponent.prototype, "Level", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Number)
    ], DropZonificacionComponent.prototype, "dependentId", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropZonificacionComponent.prototype, "LabelText", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], DropZonificacionComponent.prototype, "disable", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Output"])(),
        __metadata("design:type", Object)
    ], DropZonificacionComponent.prototype, "zone", void 0);
    DropZonificacionComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-drop-zonificacion',
            template: __webpack_require__("./src/app/site/component/dropdown/drop-zonificacion/drop-zonificacion.component.html"),
            styles: [__webpack_require__("./src/app/site/component/dropdown/drop-zonificacion/drop-zonificacion.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_1_app_site_service_Shared_parametro_service__["a" /* ParametroService */]]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1_app_site_service_Shared_parametro_service__["a" /* ParametroService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1_app_site_service_Shared_parametro_service__["a" /* ParametroService */]) === "function" && _a || Object])
    ], DropZonificacionComponent);
    return DropZonificacionComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/drop-zonificacion.component.js.map

/***/ }),

/***/ "./src/app/site/domain/Shared/Zoning.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Zoning; });
var Zoning = /** @class */ (function () {
    function Zoning(values) {
        if (values === void 0) { values = {}; }
        this.ZoningId = 0;
        this.Department = 0;
        this.Level = 0;
        this.DependentId = 0;
        Object.assign(this, values);
    }
    return Zoning;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/Zoning.js.map

/***/ }),

/***/ "./src/app/site/domain/Shared/global.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return urlSecurity; });
/* unused harmony export urlFelccService */
/* unused harmony export es */

// export const urlSockets = 'http://localhost:61610';
var urlSecurity = 'http://localhost:52969';
var urlFelccService = 'http://localhost:50218';
// export const urlGolf = 'http://localhost:50432';
// export const urlCommon = 'http://localhost:51498';
// export const urlReport = 'http://localhost:53980';
// export const urlGeneric = 'http://localhost:59500';
// export const urlConjunto = 'http://localhost:50431';
// export const urlSite = 'http://localhost:54015';
// export const urlSingle = 'http://localhost:53742';
// export const urlJasper = 'http://localhost:61853';
/*export const urlGeneric = 'http://200.87.69.146:8011';
 export const urlSecurity = 'http://200.87.69.146:8012';
 export const urlConjunto = 'http://200.87.69.146:8013';
 export const urlSingle = 'http://200.87.69.146:8014';
 export const urlSite = 'http://200.87.69.146:8015';
 export const urlSockets = 'http://200.87.69.146:8016';
 export const urlJasper = 'http://200.87.69.146:8017';
 export const urlGolf = 'http://200.87.69.146:8019';
 export const urlCommon = 'http://200.87.69.146:8018';
 export const urlReport = 'http://200.87.69.146:8020';*/
// export const urlGeneric = 'http://pluris2017.mindeportes.gob.bo:8011';
// export const urlSecurity = 'http://pluris2017.mindeportes.gob.bo:8012';
// export const urlConjunto = 'http://pluris2017.mindeportes.gob.bo:8013';
// export const urlSingle = 'http://pluris2017.mindeportes.gob.bo:8014';
// export const urlSite = 'http://pluris2017.mindeportes.gob.bo:8015';
// export const urlSockets = 'http://pluris2017.mindeportes.gob.bo:8016';
// export const urlJasper = 'http://pluris2017.mindeportes.gob.bo:8017';
// export const urlJasper = 'http://localhost:61853';
// export const urlGolf = 'http://localhost:62465';
// export const urlCommon = 'http://localhost:51498';
// export const urlReport = 'http://localhost:53980';
var es = {
    firstDayOfWeek: 1,
    dayNames: [
        'domingo',
        'lunes',
        'martes',
        'miercoles',
        'jueves',
        'viernes',
        'sabado'
    ],
    dayNamesShort: ['dom', 'lun', 'mar', 'mie', 'jue', 'vie', 'sab'],
    dayNamesMin: ['D', 'L', 'M', 'X', 'J', 'V', 'S'],
    monthNames: [
        'enero',
        'febrero',
        'marzo',
        'abril',
        'mayo',
        'junio',
        'julio',
        'agosto',
        'septiembre',
        'octubre',
        'noviembre',
        'diciembre'
    ],
    monthNamesShort: [
        'ene',
        'feb',
        'mar',
        'abr',
        'may',
        'jun',
        'jul',
        'ago',
        'sep',
        'oct',
        'nov',
        'dic'
    ]
};
//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/global.js.map

/***/ }),

/***/ "./src/app/site/domain/Shared/office.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Office; });
var Office = /** @class */ (function () {
    function Office(values) {
        if (values === void 0) { values = {}; }
        this.OfficeId = 0;
        this.Level = 0;
        this.DependentId = 0;
        Object.assign(this, values);
    }
    return Office;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/office.js.map

/***/ }),

/***/ "./src/app/site/service/Denuncias/denuncias.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DenunciasService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("./node_modules/@angular/http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Rx__ = __webpack_require__("./node_modules/rxjs/_esm5/Rx.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__ = __webpack_require__("./src/app/site/domain/Shared/global.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var DenunciasService = /** @class */ (function () {
    function DenunciasService(http) {
        this.http = http;
    }
    DenunciasService.prototype.getTypeCrimen = function () {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Felcc/getTypeCrimen")
            .toPromise()
            .then(function (r) {
            return r.json();
        });
    };
    var _a;
    DenunciasService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"]) === "function" && _a || Object])
    ], DenunciasService);
    return DenunciasService;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/denuncias.service.js.map

/***/ }),

/***/ "./src/app/site/service/Shared/parametro.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ParametroService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("./node_modules/@angular/http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Rx__ = __webpack_require__("./node_modules/rxjs/_esm5/Rx.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__ = __webpack_require__("./src/app/site/domain/Shared/global.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var ParametroService = /** @class */ (function () {
    function ParametroService(http) {
        this.http = http;
    }
    ParametroService.prototype.getParametroforCodigo = function (groupId) {
        return this.http.get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Generic/getParameters?groupId=" + groupId).toPromise().then(function (r) { return r.json().map(function (item) {
            return { label: item.Parameter, value: item.ParameterId };
        }); });
        return;
    };
    ParametroService.prototype.getParametro = function (groupId) {
        return this.http.get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Generic/getParameters?groupId=" + groupId).toPromise().then(function (r) { return r.json(); });
    };
    ParametroService.prototype.getZoning = function (level, dependentId) {
        return this.http.get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Generic/getZoning?level=" + level + "&dependentId=" + dependentId).toPromise().then(function (r) { return r.json(); });
    };
    ParametroService.prototype.getOffices = function (level, dependentId) {
        return this.http.get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Generic/getOffice?level=" + level + "&dependentId=" + dependentId).toPromise().then(function (r) { return r.json(); });
    };
    var _a;
    ParametroService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"]) === "function" && _a || Object])
    ], ParametroService);
    return ParametroService;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/parametro.service.js.map

/***/ }),

/***/ "./src/app/site/service/Shared/usuario.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UsuarioService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("./node_modules/@angular/http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Rx__ = __webpack_require__("./node_modules/rxjs/_esm5/Rx.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__ = __webpack_require__("./src/app/site/domain/Shared/global.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var UsuarioService = /** @class */ (function () {
    function UsuarioService(http) {
        this.http = http;
    }
    UsuarioService.prototype.verificarPass = function (id, clave) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/verificarClave?id=" + id + "&clave=" + clave)
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UsuarioService.prototype.getUsuariosRegistrados = function () {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/GetUsuariosRegistrados")
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UsuarioService.prototype.getUsuarioRegistrado = function (usuarioId) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/getUsuario?usuarioId=" + usuarioId)
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UsuarioService.prototype.getUsuarios = function () {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/GetUsuarios")
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UsuarioService.prototype.getLogin = function (usuario, password) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/GetUsuarioByPassword?usuario=" + usuario + "&password=" + password)
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UsuarioService.prototype.getUsuario = function (usuarioId) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/GetUsuario?usuarioId=" + usuarioId)
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UsuarioService.prototype.getToc = function (usuario) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/GetListTocs?filename=" + usuario)
            .map(function (r) { return r.json(); });
    };
    //obtener usuario para actualizar
    UsuarioService.prototype.getUser = function (usuarioId) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/GetUser?usuarioId=" + usuarioId)
            .map(function (r) { return r.json().data; });
    };
    UsuarioService.prototype.updateUser = function (data) {
        var headers = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["Headers"]({ 'Content-Type': 'application/json' });
        var options = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["RequestOptions"]({ headers: headers });
        return this.http.post(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/upUser", data.value, options);
    };
    UsuarioService.prototype.getMasterRelease = function () {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/GetMasterRelease")
            .map(function (r) { return r.json(); });
    };
    UsuarioService.prototype.getFotoPerfil = function (usuarioId) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/GetFotoPerfil?usuarioId=" + usuarioId)
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UsuarioService.prototype.handleError = function (error) {
        return Promise.reject(error.message || error);
    };
    UsuarioService.prototype.setJsonPrivilegio = function (data, usuarioId) {
        var d = '[';
        var ip = 0;
        data.forEach(function (padre) {
            if (padre.selected || padre.partialSelection) {
                if (padre.children.length) {
                    // tslint:disable-next-line:max-line-length
                    d = d + '{' + '"label":' + '"' + padre.label + '"' + ',"icon":' + '"' + padre.icon + '"' + ',"partialSelection":' + padre.partialSelection + ',"selected":' + padre.selected + ',"expanded":' + padre.expanded + ',"items":[';
                    var ih_1 = 0;
                    padre.children.forEach(function (hijo) {
                        if (hijo.selected) {
                            if (ih_1 === 0) {
                                // tslint:disable-next-line:max-line-length
                                d = d + '{' + '"label":' + '"' + hijo.label + '"' + ',"icon":' + '"' + hijo.icon + '"' + ',"routerLink":' + '["' + hijo.routerLink + '"]' + ',"selected":' + hijo.selected + ',"expanded":' + padre.expanded + '}';
                            }
                            else {
                                // tslint:disable-next-line:max-line-length
                                d = d + ',{' + '"label":' + '"' + hijo.label + '"' + ',"icon":' + '"' + hijo.icon + '"' + ',"routerLink":' + '["' + hijo.routerLink + '"]' + ',"selected":' + hijo.selected + ',"expanded":' + padre.expanded + '}';
                            }
                            ih_1++;
                        }
                    });
                    if (ip === 0) {
                        d = d + ']}';
                    }
                    else {
                        d = d + ']},';
                    }
                    ip++;
                }
                else {
                    // tslint:disable-next-line:max-line-length
                    d = d + '{' + '"label":' + '"' + padre.label + '"' + ',"icon":' + '"' + padre.icon + '"' + ',"routerLink":' + '["' + padre.routerLink + '"]' + ',"selected":' + padre.selected + ',"expanded":' + padre.expanded + '},';
                    ip++;
                }
            }
        });
        d = d + ']';
        var dataset = { UsuarioId: usuarioId, TOCJson: d };
        var headers = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["Headers"]({ 'Content-Type': 'application/json' });
        var options = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["RequestOptions"]({ headers: headers });
        return this.http.post(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/setJsonPrivilegioUsuario", dataset, options);
    };
    //M.eliminar Usuario
    UsuarioService.prototype.deleteUsuario = function (usuarioId) {
        var headers = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["Headers"]({ 'Content-Type': 'application/json' });
        var options = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["RequestOptions"]({ headers: headers });
        return this.http.delete(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/DeleteUser?usuarioId=" + usuarioId, options);
    };
    UsuarioService.prototype.setPassword = function (data) {
        var headers = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["Headers"]({ 'Content-Type': 'application/json' });
        var options = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["RequestOptions"]({ headers: headers });
        return this.http.post(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/SaveNewPass", data.value, options);
    };
    UsuarioService.prototype.setUsuario = function (data) {
        var headers = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["Headers"]({ 'Content-Type': 'application/json' });
        var options = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["RequestOptions"]({ headers: headers });
        return this.http.post(__WEBPACK_IMPORTED_MODULE_3__domain_Shared_global__["a" /* urlSecurity */] + "/api/Security/AddUsuario", data.value, options);
    };
    var _a;
    UsuarioService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"]) === "function" && _a || Object])
    ], UsuarioService);
    return UsuarioService;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/usuario.service.js.map

/***/ }),

/***/ "./src/app/site/shared/auth.guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AuthGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("./node_modules/@angular/router/@angular/router.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var AuthGuard = /** @class */ (function () {
    function AuthGuard(router) {
        this.router = router;
    }
    AuthGuard.prototype.canActivate = function () {
        try {
            var usuarioActual = JSON.parse(sessionStorage.getItem('resu'));
            if (usuarioActual.UserId > 0) {
                return true;
            }
            this.router.navigate(['/login']);
            return false;
        }
        catch (e) {
            this.router.navigate(['/login']);
            return false;
        }
    };
    var _a;
    AuthGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"]) === "function" && _a || Object])
    ], AuthGuard);
    return AuthGuard;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/auth.guard.js.map

/***/ }),

/***/ "./src/app/site/view/Administracion/usuario/user-pass/user-pass.component.css":
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/site/view/Administracion/usuario/user-pass/user-pass.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"ui-g \">\n  <div class=\"card card-w-title ui-fluid ui-g-12\">\n    <form id=\"DatosPesonalesForm\" [(formGroup)]=\"DatosPesonalesForm\">\n <p-panel #pnl header=\" Cambio de contraseña para {{ _nombre}}\" [style]=\"{'margin-top':'20px'}\">\n <div class=\"ui-grid ui-grid-responsive ui-grid-pad ui-fluid\" style=\"margin: 10px 0px\">\n\n <div class=\"ui-g-4 \"></div>\n <div class=\"form-group ui-g-4\">\n\n    <div class=\"ui-g-12 ui-md-12\">\n          <span class=\"md-inputfield\">\n          <input type=\"password\" pInputText style=\"width:100% !important\"  formControlName=\"oldpassword\">\n          <label>Ingrese su contraseña:</label>\n        </span>\n        </div>\n    <div class=\" ui-grid-col-12 ui-message ui-messages-error ui-corner-all\" style=\"padding:0.4em !important; width: auto;\" *ngIf=\"_oldpassword_valid\">\n      Su contraseña actual no puede estar vacia.\n    </div>\n    <div class=\" ui-grid-col-12 ui-message ui-messages-error ui-corner-all\" style=\"padding:0.4em !important; width: auto;\" *ngIf=\"_clave_valid\">\n      Ingrese su contraseña actual\n    </div>\n    <div class=\"ui-g-12 ui-md-12\">\n      <span class=\"md-inputfield\">\n      <input type=\"password\" pInputText style=\"width:100% !important\"  formControlName=\"newpassword\">\n      <label>Nueva contraseña:</label>\n    </span>\n    </div>\n     <div class=\" ui-grid-col-12 ui-message ui-messages-error ui-corner-all\" style=\"padding:0.4em !important; width: auto;\" *ngIf=\"_newpassword_valid\">\n      Debe ingresar su nueva contraseña\n    </div>\n    <div class=\" ui-grid-col-12 ui-message ui-messages-error ui-corner-all\" style=\"padding:0.4em !important; width: auto;\" *ngIf=\"_igualpass\">\n      Su nueva contraseña debe ser igual a su confirmación.\n    </div>\n    <div class=\"ui-g-12 ui-md-12\">\n      <span class=\"md-inputfield\">\n      <input type=\"password\" pInputText style=\"width:100% !important\"  formControlName=\"repassword\">\n      <label>Confirmar contraseña:</label>\n    </span>\n    </div>\n     <div class=\" ui-grid-col-12 ui-message ui-messages-error ui-corner-all\" style=\"padding:0.4em !important; width: auto;\" *ngIf=\"_repassword_valid\">\n      La confirmación no puede estar vacia.\n    </div>\n<div class=\"ui-g-12 ui-md-12\"></div>\n    <div class=\"ui-g-3 ui-md-3\" style=\"text-align:left\">\n    <button type=\"button\" label=\"Registrar Datos\" pButton  (click)=\"onSave()\" style=\"min-width:150px\"></button>\n  </div>\n\n</div>\n\n</div>\n\n<p-growl [value]=\"msgs\"></p-growl>\n</p-panel> \n</form>\n</div>\n</div>"

/***/ }),

/***/ "./src/app/site/view/Administracion/usuario/user-pass/user-pass.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UserPassComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_forms__ = __webpack_require__("./node_modules/@angular/forms/@angular/forms.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__service_Shared_usuario_service__ = __webpack_require__("./src/app/site/service/Shared/usuario.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var UserPassComponent = /** @class */ (function () {
    function UserPassComponent(formBuilder, usuarioServicio) {
        this.formBuilder = formBuilder;
        this.usuarioServicio = usuarioServicio;
        this._oldpassword_valid = false;
        this._newpassword_valid = false;
        this._repassword_valid = false;
        this._clave_valid = false;
        this._igualpass = false;
        this._verificar_oldpass = false;
        this.msgs = [];
    }
    UserPassComponent.prototype.ngOnInit = function () {
        this.init_formulario();
        this.loadUsuarioActual();
    };
    UserPassComponent.prototype.loadUsuarioActual = function () {
        var _this = this;
        var usuarioActual = JSON.parse(sessionStorage.getItem('resu'));
        this.identificador = usuarioActual.UsuarioId;
        this.usuarioServicio.getUsuarioRegistrado(usuarioActual.UsuarioId).then(function (res) {
            _this.datos = res;
            _this._nombre = _this.datos.Usuario.toLowerCase().replace('.', ' ');
        });
    };
    UserPassComponent.prototype.onSave = function () {
        var _this = this;
        if (this.validar()) {
            this.DatosPesonalesForm.controls['UsuarioId'].setValue(this.identificador);
            this.DatosPesonalesForm.controls['Password'].setValue(this.DatosPesonalesForm.controls['newpassword'].value);
            this.usuarioServicio.verificarPass(this.identificador, this.DatosPesonalesForm.controls['oldpassword'].value).then(function (res) {
                _this._clave_valid = !res;
                if (!_this._clave_valid) {
                    _this.setPassword();
                }
            });
        }
    };
    UserPassComponent.prototype.setPassword = function () {
        var _this = this;
        this.usuarioServicio.setPassword(this.DatosPesonalesForm).subscribe(function (res) {
            var resp = res.json();
            if (resp === true) {
                _this.showMessage();
                // this.DatosPesonalesForm.reset;
                _this.DatosPesonalesForm.controls['newpassword'].setValue('');
                _this.DatosPesonalesForm.controls['oldpassword'].setValue('');
                _this.DatosPesonalesForm.controls['repassword'].setValue('');
            }
        });
    };
    UserPassComponent.prototype.init_formulario = function () {
        this.DatosPesonalesForm = this.formBuilder.group({
            oldpassword: ['', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].compose([__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required])],
            newpassword: ['', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].compose([__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required])],
            repassword: ['', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].compose([__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required])],
            Password: ['', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].compose([__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required])],
            UsuarioId: ['', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].compose([__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required])]
        });
    };
    UserPassComponent.prototype.showMessage = function () {
        this.msgs = [];
        this.msgs.push({ severity: 'success', summary: 'Exito!', detail: 'Contraseña actualizada' });
    };
    UserPassComponent.prototype.validar = function () {
        this._oldpassword_valid = !this.DatosPesonalesForm.controls['oldpassword'].valid;
        this._newpassword_valid = !this.DatosPesonalesForm.controls['newpassword'].valid;
        this._repassword_valid = !this.DatosPesonalesForm.controls['repassword'].valid;
        var data_newpassword = this.DatosPesonalesForm.controls['newpassword'].value;
        var data_repassword = this.DatosPesonalesForm.controls['repassword'].value;
        if (data_newpassword === data_repassword) {
            this._igualpass = false;
        }
        else {
            this._igualpass = true;
        }
        if (!this._oldpassword_valid && !this._newpassword_valid && !this._repassword_valid && !this._igualpass) {
            return true;
        }
        else {
            return false;
        }
    };
    var _a, _b;
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Array)
    ], UserPassComponent.prototype, "DatosPesonalesInput", void 0);
    UserPassComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-user-pass',
            template: __webpack_require__("./src/app/site/view/Administracion/usuario/user-pass/user-pass.component.html"),
            styles: [__webpack_require__("./src/app/site/view/Administracion/usuario/user-pass/user-pass.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_2__service_Shared_usuario_service__["a" /* UsuarioService */]]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormBuilder"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormBuilder"]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_2__service_Shared_usuario_service__["a" /* UsuarioService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__service_Shared_usuario_service__["a" /* UsuarioService */]) === "function" && _b || Object])
    ], UserPassComponent);
    return UserPassComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/user-pass.component.js.map

/***/ }),

/***/ "./src/app/site/view/Denuncias/denuncias.route.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DenunciasRoutes; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__Denuncias_vw_formulario_vw_formulario_component__ = __webpack_require__("./src/app/site/view/Denuncias/vw-formulario/vw-formulario.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Denuncias_vw_listados_vw_listados_component__ = __webpack_require__("./src/app/site/view/Denuncias/vw-listados/vw-listados.component.ts");


var DenunciasRoutes = [
    { path: 'form-denuncias', component: __WEBPACK_IMPORTED_MODULE_0__Denuncias_vw_formulario_vw_formulario_component__["a" /* VwFormularioComponent */] },
    { path: 'form-vw-listado', component: __WEBPACK_IMPORTED_MODULE_1__Denuncias_vw_listados_vw_listados_component__["a" /* VwListadosComponent */] }
];
//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/denuncias.route.js.map

/***/ }),

/***/ "./src/app/site/view/Denuncias/vw-formulario/vw-formulario.component.css":
/***/ (function(module, exports) {

module.exports = "#div_form span \r\n{\r\npadding-left: 10px;\r\npadding-right: 10px;\r\npadding-bottom: 25px;\r\n}\r\n"

/***/ }),

/***/ "./src/app/site/view/Denuncias/vw-formulario/vw-formulario.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"ui-g\">\n  <div class=\"ui-g-12\">\n    <div class=\"card card-w-title\">\n  <h1>Registro de Denuncias</h1>\n \n  <p-tabView>\n    <p-tabPanel header=\"Delito\" leftIcon=\"pi pi-calendar\">\n        <div  class=\"ui-g\" >\n    <p-fieldset class=\"ui-g-12\" legend=\"Detalle\">\n      <div class=\"ui-g-6\" style=\"width:250px;margin-bottom:10px\" >\n          <div class=\"ui-g\" *ngFor=\"let item of _Delitos\">\n              <div class=\"ui-g\">\n                 <p-checkbox name=\"group1\" value=\"{{item.TypeCrimeId}}\"label=\"{{item.Crime}}\" [(ngModel)]=\"selectedCities\" inputId=\"sf\"></p-checkbox> \n                </div>\n            </div>\n        </div>\n        <div id=\"div_form\" class=\"ui-g\" >\n                <span>\n                    <app-drop-parametros class=\"form-control\"    [GroupId]=6 LabelText=\"Divici&#243;n\"  (Parameter)=\"SelectParametro($event)\" [Filter]=\"true\"  ></app-drop-parametros>\n                </span>\n                <span class=\"md-inputfield\">\n                        <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"1\"/>\n                        <label>Nro. Caso Fiscal</label>\n                </span>\n                <span>\n                        <app-drop-offices [Level]=1 [dependentId]=1 LabelText=\"Departamento\" (office)=\"SelectOfficeDepartamento($event)\" [Filter]=\"true\"  ></app-drop-offices>\n                </span>\n                <span>\n                        <app-drop-offices [Level]=2 [dependentId]=\"_office.OfficeId\" LabelText=\"Comisaria\" (office)=\"SelectOfficeComiseria($event)\" [Filter]=\"true\"  ></app-drop-offices>\n                </span>\n            </div>\n        </p-fieldset>\n    </div>\n    </p-tabPanel>\n    <p-tabPanel header=\"Denunciante\" leftIcon=\"ui-icon-person\">\n      <div class=\"ui-g\">\n\n      <p-fieldset class=\"ui-g-6\" legend=\"Datos Personales\">\n         <div id=\"div_form\"class=\"ui-g\">\n                  <span class=\"md-inputfield\">\n                      <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"1\"/>\n                      <label>Nombre</label>\n                  </span>\n                  <span class=\"md-inputfield\">\n                        <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"2\" />\n                        <label>Segundo Nombre</label>\n                    </span>\n                  <span class=\"md-inputfield\">\n                      <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"3\" />\n                      <label>Paterno</label>\n                  </span>\n                  <span class=\"md-inputfield\">\n                        <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"4\" />\n                        <label>Materno</label>\n                    </span>\n                <span class=\"md-inputfield\">\n                      <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"5\" />\n                      <label>Nro. Documentos</label>\n                  </span>\n                  <span>\n                        <app-drop-parametros class=\"form-control\" [GroupId]=1 LabelText=\"Extenci&#243;n\"  (Parameter)=\"SelectParametro($event)\"  ></app-drop-parametros>\n                  </span>\n                  <span>\n                        <app-drop-parametros class=\"form-control\" [GroupId]=4 LabelText=\"Genero\"  (Parameter)=\"SelectParametro($event)\"  ></app-drop-parametros>\n                  </span>\n                  <span class=\"md-inputfield\">\n                  <p-calendar [(ngModel)]=\"FechaNac\" [showIcon]=\"true\"></p-calendar>\n                  <label>Fecha Nac. dd/mm/yyyy</label>\n                </span>\n                  <span>\n                        <app-drop-parametros class=\"form-control\" [GroupId]=5 LabelText=\"Estado Civil\"  (Parameter)=\"SelectParametro($event)\"  ></app-drop-parametros>\n                  </span>\n                  <span >   \n                    <app-drop-parametros class=\"form-control\" [GroupId]=2 LabelText=\"Nacionalidad\"  (Parameter)=\"SelectParametro($event)\"  ></app-drop-parametros>\n                  </span>\n                  <span class=\"md-inputfield\">\n                      <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"7\" />\n                      <label>Domicilio</label>\n                  </span>\n                  <span class=\"md-inputfield\">\n                        <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"6\" />\n                        <label>Telefono</label>\n                    </span>\n         </div> \n      </p-fieldset>\n      <p-fieldset class=\"ui-g-6\" legend=\"Datos Laborales\">\n            <div id=\"div_form\" class=\"ui-g-12\">\n                <span class=\"md-inputfield\">\n                    <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"1\"/>\n                    <label>Profesión/Ocupación</label>\n                </span>\n                <span class=\"md-inputfield\">\n                    <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"9\" />\n                    <label>Lugar de Trabajo</label>\n                </span>\n                <span class=\"md-inputfield\">\n                    <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"10\" />\n                    <label>Nro. Telefonico</label>\n                </span>\n                <span class=\"md-inputfield\">\n                    <input type=\"text\" pInputText  class=\"form-control\" tabindex=\"11\" />\n                    <label>Dirección</label>\n                </span>\n        </div>\n      </p-fieldset>\n      </div>\n    </p-tabPanel>\n    <p-tabPanel header=\"Hechos\" leftIcon=\"pi pi-user\" rightIcon=\"pi pi-star\">\n        <p-fieldset class=\"ui-g\" legend=\"Locación/Ubicacion\">\n        <div id=\"div_form\" class=\"ui-g\">    \n            <span>\n                <app-drop-zonificacion [Level]=0 [dependentId]=0 LabelText=\"Departamento\" (zone)=\"SelectDepartment($event)\"></app-drop-zonificacion>\n            </span>\n            <span>\n                <app-drop-zonificacion [Level]=1 [dependentId]=\"_department.ZoningId\" LabelText=\"Provincia\" (zone)=\"SelectProvince($event)\"></app-drop-zonificacion>\n            </span>\n            <span>\n                <app-drop-zonificacion [Level]=2 [dependentId]=\"_province.ZoningId\" LabelText=\"Municipio\" (zone)=\"SelectMunicipio($event)\"></app-drop-zonificacion>\n            </span>\n            <span>\n                <app-drop-zonificacion [Level]=3 [dependentId]=\"_municipality.ZoningId\" LabelText=\"Zona\" (zone)=\"SelectZona($event)\"></app-drop-zonificacion>\n            </span>\n            <span>\n            <app-drop-parametros  [style]=\"{'width':'150px'}\" class=\"form-control\" [GroupId]=3 LabelText=\"Tipo Via\"  (Parameter)=\"SelectParametro($event)\"  ></app-drop-parametros>\n             </span>\n            <span class=\"md-inputfield\">\n                <input style=\"width:250px\"  type=\"text\" pInputText  class=\"form-control\" tabindex=\"1\"/>\n                <label>Nombre de Calle/Avenida</label>\n            </span>\n            <span class=\"md-inputfield\">\n                <input style=\"width:250px\"   type=\"text\" pInputText  class=\"form-control\" tabindex=\"1\"/>\n                <label>Resto de Direccion</label>\n            </span>\n            <span class=\"md-inputfield\">\n                    <p-calendar [(ngModel)]=\"FechaNac\" [showIcon]=\"true\"></p-calendar>\n            <label>Fecha dd/mm/yyyy</label>\n            </span>\n            <span class=\"md-inputfield\">\n                    <p-calendar [(ngModel)]=\"FechaNac\" [showIcon]=\"true\" [timeOnly]=\"true\" ></p-calendar>\n            <label>Hora Aprox:</label>\n            </span>\n       </div> \n    </p-fieldset>\n    <p-fieldset legend=\"Breve detalle del Hecho\">\n            <p-editor [(ngModel)]=\"text\" [style]=\"{'height':'320px'}\"></p-editor>\n    </p-fieldset>\n    </p-tabPanel>\n    <p-tabPanel header=\"Objetos\" leftIcon=\"pi pi-user\" rightIcon=\"pi pi-star\">\n      After a break of more than  15 years, director Francis Ford Coppola and writer Mario Puzo returned to the well for this third and final story of the fictional Corleone crime family. Two decades have passed, and crime kingpin Michael Corleone, now divorced from his wife Kay has nearly succeeded in keeping his promise that his family would one day be completely legitimate.\n  </p-tabPanel>\n  </p-tabView>\n  </div>\n  </div>\n  </div>"

/***/ }),

/***/ "./src/app/site/view/Denuncias/vw-formulario/vw-formulario.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return VwFormularioComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__service_Denuncias_denuncias_service__ = __webpack_require__("./src/app/site/service/Denuncias/denuncias.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_app_site_domain_Shared_Zoning__ = __webpack_require__("./src/app/site/domain/Shared/Zoning.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_app_site_domain_Shared_office__ = __webpack_require__("./src/app/site/domain/Shared/office.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var VwFormularioComponent = /** @class */ (function () {
    function VwFormularioComponent(denunciasService) {
        this.denunciasService = denunciasService;
    }
    VwFormularioComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._department = new __WEBPACK_IMPORTED_MODULE_2_app_site_domain_Shared_Zoning__["a" /* Zoning */]();
        this._province = new __WEBPACK_IMPORTED_MODULE_2_app_site_domain_Shared_Zoning__["a" /* Zoning */]();
        this._municipality = new __WEBPACK_IMPORTED_MODULE_2_app_site_domain_Shared_Zoning__["a" /* Zoning */]();
        this._zone = new __WEBPACK_IMPORTED_MODULE_2_app_site_domain_Shared_Zoning__["a" /* Zoning */]();
        this._office = new __WEBPACK_IMPORTED_MODULE_3_app_site_domain_Shared_office__["a" /* Office */]();
        this.FechaNac = new Date();
        this.denunciasService.getTypeCrimen().then(function (res) {
            _this._Delitos = res;
        });
    };
    VwFormularioComponent.prototype.SelectParametro = function ($event) {
        console.log($event);
    };
    VwFormularioComponent.prototype.SelectDepartment = function ($event) {
        this._department = $event;
    };
    VwFormularioComponent.prototype.SelectProvince = function ($event) {
        this._province = $event;
    };
    VwFormularioComponent.prototype.SelectMunicipio = function ($event) {
        this._municipality = $event;
    };
    VwFormularioComponent.prototype.SelectZona = function ($event) {
        this._zone = $event;
    };
    VwFormularioComponent.prototype.SelectOfficeDepartamento = function ($event) {
        debugger;
        this._office = $event;
    };
    VwFormularioComponent.prototype.SelectOfficeComiseria = function ($event) { };
    var _a;
    VwFormularioComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-vw-formulario',
            template: __webpack_require__("./src/app/site/view/Denuncias/vw-formulario/vw-formulario.component.html"),
            styles: [__webpack_require__("./src/app/site/view/Denuncias/vw-formulario/vw-formulario.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_1__service_Denuncias_denuncias_service__["a" /* DenunciasService */]]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__service_Denuncias_denuncias_service__["a" /* DenunciasService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__service_Denuncias_denuncias_service__["a" /* DenunciasService */]) === "function" && _a || Object])
    ], VwFormularioComponent);
    return VwFormularioComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/vw-formulario.component.js.map

/***/ }),

/***/ "./src/app/site/view/Denuncias/vw-listados/vw-listados.component.css":
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/site/view/Denuncias/vw-listados/vw-listados.component.html":
/***/ (function(module, exports) {

module.exports = "\n<div class=\"ui-g\">\n  <div class=\"ui-g-12\">\n    <div class=\"card card-w-title\">\n  <h1>Listado de Denuncias</h1>\n  <div class=\"ui-g\">\n    <div class=\"ui-g-4\"></div>\n    <div class=\"ui-g-4\" style=\"text-align:center\"> <p-calendar [(ngModel)]=\"date1\" [showIcon]=\"true\"></p-calendar></div>\n    <div class=\"ui-g-4\"></div>\n  </div>\n      <div class=\"ui-widget-header\" style=\"padding:4px 8px;border-bottom: 0 none;text-align:right;background-color:#424242\">                \n              <div class=\"row ui-toolbar-group-left\">\n                  <button pButton type=\"button\" icon=\"ui-icon-plus\" class=\"green-btn\" (click)=\"addDenuncias()\"></button> \n                  <button pButton type=\"button\" icon=\"ui-icon-delete\" class=\"teal-btn\" (click)=\"confirmDelete()\" *ngIf=\"hideElement\"></button>\n                  <button pButton type=\"button\" icon=\"ui-icon-edit\" class=\"teal-btn\" (click)=\"showDialog(this.type.Actualizar)\" *ngIf=\"hideElement\" ></button>    \n  \n              </div>        \n                  <i class=\"fa fa-search\" style=\"margin:4px 4px 0 0\"></i>\n                      <input #gb type=\"text\" pInputText size=\"25\" style = \"color:white\" placeholder=\"Buscar\">\n      </div>\n  \n      <p-dataTable [value]=\"lista\" [responsive]=\"true\" selectionMode=\"single\"  \n      [(selection)]=\"Usuario\" \n     \n      [rows]=\"10\" [paginator]=\"true\"  [globalFilter]=\"gb\">\n      <!-- (onRowUnselect)=\"onRowUnselect($event)\"\n      (onRowDblclick)=\"handleRowDblclickUsuario($event)\"  -->\n                  <p-column field=\"Usuario\" header=\"Nro. Denuncia\" size=\"40\"></p-column>\n                  <p-column field=\"Usuario\" header=\"Nro. Caso\" size=\"40\"></p-column>\n                  <p-column field=\"Usuario\" header=\"Tipo de Denuncia\" size=\"40\"></p-column>\n                  <p-column field=\"Usuario\" header=\"División\" size=\"40\"></p-column>\n                  <p-column field=\"Usuario\" header=\"Denunciante\" size=\"40\"></p-column>\n                  <p-column field=\"FechaRegistro\" header=\"Fecha Registro\" size=\"8\">\n                      <ng-template let-col let-fecha=\"rowData\" pTemplate=\"body\">\n                          {{fecha[col.field] | date:'shortDate'}}\n                      </ng-template>\n                  </p-column>\n                  <p-column field=\"IsActivo\" header=\"Estado\" size=\"1\">\n                      <ng-template let-col let-estado=\"rowData\" pTemplate=\"body\">\n                          <div class=\"circulo\" [style.background]=\"estado[col.field]===false?'Red':'Green'\"></div>\n                      </ng-template>\n                  </p-column>\n       </p-dataTable>\n     </div>\n  </div>\n  </div>\n\n  "

/***/ }),

/***/ "./src/app/site/view/Denuncias/vw-listados/vw-listados.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return VwListadosComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("./node_modules/@angular/router/@angular/router.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var VwListadosComponent = /** @class */ (function () {
    function VwListadosComponent(router, route) {
        this.router = router;
        this.route = route;
    }
    VwListadosComponent.prototype.ngOnInit = function () {
    };
    VwListadosComponent.prototype.addDenuncias = function () {
        this.router.navigate(['/master/form-denuncias/']);
    };
    var _a, _b;
    VwListadosComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-vw-listados',
            template: __webpack_require__("./src/app/site/view/Denuncias/vw-listados/vw-listados.component.html"),
            styles: [__webpack_require__("./src/app/site/view/Denuncias/vw-listados/vw-listados.component.css")]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"]) === "function" && _b || Object])
    ], VwListadosComponent);
    return VwListadosComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/vw-listados.component.js.map

/***/ }),

/***/ "./src/app/site/view/components/login/login.component.html":
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"card login-panel ui-fluid\">\r\n    <div class=\"ui-g\">\r\n        <div class=\"ui-g-12\">\r\n            <img src=\"assets/erpHammer/images/hammerLogoV.png\" width=\"120\">\r\n        </div>\r\n        <form class=\"form-login\" [formGroup]=\"loginForm\" (ngSubmit)=\"doLogin($event)\">\r\n            <div class=\"ui-g-12\">\r\n                <span class=\"md-inputfield\">\r\n                    <input type=\"text\" pInputText formControlName=\"userName\" class=\"form-control\" />\r\n                    <label>Usuario</label>\r\n                </span>\r\n            </div>\r\n            <div class=\"ui-g-12\">\r\n                <span class=\"md-inputfield\">\r\n                    <input pPassword type=\"password\" formControlName=\"password\" class=\"form-control\" [feedback]=\"false\"/>\r\n                    <label>Contraseña</label>\r\n                </span>\r\n            </div>\r\n            <div class=\"ui-g-12\">\r\n                <button class=\"ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icon-left\" [routerLink]=\"['/master']\">\r\n                    <!--[routerLink]=\"['/master']\"-->\r\n                    <span class=\"ui-button-icon-left ui-c fa fa-fw ui-icon-person\"></span>\r\n                    <span class=\"ui-button-text ui-c\">Entrar</span>\r\n                </button>\r\n                <!-- <button type=\"button\" class=\"secondary ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icon-left\">\r\n                    <span class=\"ui-button-icon-left ui-c fa fa-fw ui-icon-help\"></span>\r\n                    <span class=\"ui-button-text ui-c\">Registrarse</span>\r\n                </button> -->\r\n            </div>\r\n        </form>\r\n    </div>\r\n    <p-messages [value]=\"msgs\"></p-messages>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/site/view/components/login/login.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Login; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_forms__ = __webpack_require__("./node_modules/@angular/forms/@angular/forms.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_http__ = __webpack_require__("./node_modules/@angular/http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_router__ = __webpack_require__("./node_modules/@angular/router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__service_Shared_usuario_service__ = __webpack_require__("./src/app/site/service/Shared/usuario.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_rxjs_Rx__ = __webpack_require__("./node_modules/rxjs/_esm5/Rx.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





// import { SocketService } from '../../../service/Shared/socket.service';

var Login = /** @class */ (function () {
    function Login(formBuilder, http, usuarioService, router
    // private socket: SocketService
    ) {
        this.formBuilder = formBuilder;
        this.http = http;
        this.usuarioService = usuarioService;
        this.router = router;
        this.msgs = [];
    }
    Login.prototype.ngOnInit = function () {
        this.loginForm = this.formBuilder.group({
            userName: ['', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required],
            password: ['', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]
        });
    };
    Login.prototype.doLogin = function () {
        var _this = this;
        this.usuarioService.getLogin(this.loginForm.value.userName, this.loginForm.value.password)
            .then(function (res) {
            _this.usuario = res;
            if (_this.usuario.UserId > 0) {
                sessionStorage.setItem('resu', JSON.stringify(_this.usuario));
                _this.router.navigate(['/master']);
            }
            else {
                _this.msgs = [];
                _this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error de autentificación' });
                setTimeout(function () { _this.msgs = []; }, 2500);
            }
        }).catch(function (error) {
            _this.msgs = [];
            _this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error de conexión con el servidor' });
            setTimeout(function () { _this.msgs = []; }, 2500);
        });
    };
    var _a, _b, _c, _d;
    Login = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'login',
            template: __webpack_require__("./src/app/site/view/components/login/login.component.html"),
            providers: [__WEBPACK_IMPORTED_MODULE_4__service_Shared_usuario_service__["a" /* UsuarioService */]]
        })
        // tslint:disable-next-line:component-class-suffix
        ,
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormBuilder"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormBuilder"]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_2__angular_http__["Http"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__angular_http__["Http"]) === "function" && _b || Object, typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_4__service_Shared_usuario_service__["a" /* UsuarioService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_4__service_Shared_usuario_service__["a" /* UsuarioService */]) === "function" && _c || Object, typeof (_d = typeof __WEBPACK_IMPORTED_MODULE_3__angular_router__["Router"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_3__angular_router__["Router"]) === "function" && _d || Object])
    ], Login);
    return Login;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/login.component.js.map

/***/ }),

/***/ "./src/app/site/view/components/mastePage/master-page.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"layout-wrapper\" [ngClass]=\"{'layout-compact':layoutCompact}\">\r\n    <div #layoutContainer class=\"layout-container\"\r\n         [ngClass]=\"{'menu-layout-static': !isOverlay(),\r\n            'menu-layout-overlay': isOverlay(),\r\n            'layout-menu-overlay-active': overlayMenuActive,\r\n            'menu-layout-horizontal': isHorizontal(),\r\n            'layout-menu-static-inactive': staticMenuDesktopInactive,\r\n            'layout-menu-static-active': staticMenuMobileActive}\">\r\n         <app-topbar></app-topbar> \r\n        <div class=\"layout-menu\" [ngClass]=\"{'layout-menu-dark':darkMenu}\" (click)=\"onMenuClick($event)\">\r\n            <div #layoutMenuScroller class=\"nano\">\r\n                <div class=\"nano-content menu-scroll-content\">\r\n                    <inline-profile *ngIf=\"!isHorizontal()\"></inline-profile>\r\n                     <app-menu [reset]=\"resetMenu\"></app-menu>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"layout-main\">\r\n\r\n        <div layout=\"row\">\r\n            <div layout=\"column\">\r\n                <div flex style=\"min-height:750px\">\r\n                    <router-outlet></router-outlet>\r\n                 </div>\r\n                 <div flex>\r\n                    <app-footer></app-footer>\r\n                 </div>\r\n            </div>\r\n        </div>\r\n       \r\n        </div>\r\n \r\n        <div class=\"layout-mask\"></div>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "./src/app/site/view/components/mastePage/master-page.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MasterPage; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var MenuOrientation;
(function (MenuOrientation) {
    MenuOrientation[MenuOrientation["STATIC"] = 0] = "STATIC";
    MenuOrientation[MenuOrientation["OVERLAY"] = 1] = "OVERLAY";
    MenuOrientation[MenuOrientation["HORIZONTAL"] = 2] = "HORIZONTAL";
})(MenuOrientation || (MenuOrientation = {}));
;
var MasterPage = /** @class */ (function () {
    function MasterPage(renderer) {
        this.renderer = renderer;
        this.layoutCompact = true;
        this.layoutMode = MenuOrientation.STATIC;
        this.darkMenu = false;
        this.profileMode = 'inline';
    }
    MasterPage.prototype.ngAfterViewInit = function () {
        var _this = this;
        this.layoutContainer = this.layourContainerViewChild.nativeElement;
        this.layoutMenuScroller = this.layoutMenuScrollerViewChild.nativeElement;
        // hides the horizontal submenus or top menu if outside is clicked
        this.documentClickListener = this.renderer.listenGlobal('body', 'click', function (event) {
            if (!_this.topbarItemClick) {
                _this.activeTopbarItem = null;
                _this.topbarMenuActive = false;
            }
            if (!_this.menuClick && _this.isHorizontal()) {
                _this.resetMenu = true;
            }
            _this.topbarItemClick = false;
            _this.menuClick = false;
        });
        setTimeout(function () {
            jQuery(_this.layoutMenuScroller).nanoScroller({ flash: true });
        }, 10);
    };
    MasterPage.prototype.onMenuButtonClick = function (event) {
        this.rotateMenuButton = !this.rotateMenuButton;
        this.topbarMenuActive = false;
        if (this.layoutMode === MenuOrientation.OVERLAY) {
            this.overlayMenuActive = !this.overlayMenuActive;
        }
        else {
            if (this.isDesktop()) {
                this.staticMenuDesktopInactive = !this.staticMenuDesktopInactive;
            }
            else {
                this.staticMenuMobileActive = !this.staticMenuMobileActive;
            }
        }
        event.preventDefault();
    };
    MasterPage.prototype.onMenuClick = function ($event) {
        var _this = this;
        this.menuClick = true;
        this.resetMenu = false;
        if (!this.isHorizontal()) {
            setTimeout(function () {
                jQuery(_this.layoutMenuScroller).nanoScroller();
            }, 500);
        }
    };
    MasterPage.prototype.onTopbarMenuButtonClick = function (event) {
        this.topbarItemClick = true;
        this.topbarMenuActive = !this.topbarMenuActive;
        if (this.overlayMenuActive || this.staticMenuMobileActive) {
            this.rotateMenuButton = false;
            this.overlayMenuActive = false;
            this.staticMenuMobileActive = false;
        }
        event.preventDefault();
    };
    MasterPage.prototype.onTopbarItemClick = function (event, item) {
        this.topbarItemClick = true;
        if (this.activeTopbarItem === item) {
            this.activeTopbarItem = null;
        }
        else {
            this.activeTopbarItem = item;
        }
        event.preventDefault();
    };
    MasterPage.prototype.isTablet = function () {
        var width = window.innerWidth;
        return width <= 1024 && width > 640;
    };
    MasterPage.prototype.isDesktop = function () {
        return window.innerWidth > 1024;
    };
    MasterPage.prototype.isMobile = function () {
        return window.innerWidth <= 640;
    };
    MasterPage.prototype.isOverlay = function () {
        return this.layoutMode === MenuOrientation.OVERLAY;
    };
    MasterPage.prototype.isHorizontal = function () {
        return this.layoutMode === MenuOrientation.HORIZONTAL;
    };
    MasterPage.prototype.changeToStaticMenu = function () {
        this.layoutMode = MenuOrientation.STATIC;
    };
    MasterPage.prototype.changeToOverlayMenu = function () {
        this.layoutMode = MenuOrientation.OVERLAY;
    };
    MasterPage.prototype.changeToHorizontalMenu = function () {
        this.layoutMode = MenuOrientation.HORIZONTAL;
    };
    MasterPage.prototype.ngOnDestroy = function () {
        if (this.documentClickListener) {
            this.documentClickListener();
        }
        jQuery(this.layoutMenuScroller).nanoScroller({ flash: true });
    };
    var _a, _b, _c;
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])('layoutContainer'),
        __metadata("design:type", typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"]) === "function" && _a || Object)
    ], MasterPage.prototype, "layourContainerViewChild", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])('layoutMenuScroller'),
        __metadata("design:type", typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"]) === "function" && _b || Object)
    ], MasterPage.prototype, "layoutMenuScrollerViewChild", void 0);
    MasterPage = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-root',
            template: __webpack_require__("./src/app/site/view/components/mastePage/master-page.component.html"),
        })
        // tslint:disable-next-line:component-class-suffix
        ,
        __metadata("design:paramtypes", [typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["Renderer"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_0__angular_core__["Renderer"]) === "function" && _c || Object])
    ], MasterPage);
    return MasterPage;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/master-page.component.js.map

/***/ }),

/***/ "./src/app/site/view/components/mastePage/master-page.routes.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MasterRoutes; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__mastePage_master_page_component__ = __webpack_require__("./src/app/site/view/components/mastePage/master-page.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__shared_auth_guard__ = __webpack_require__("./src/app/site/shared/auth.guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Denuncias_denuncias_route__ = __webpack_require__("./src/app/site/view/Denuncias/denuncias.route.ts");


// import { UsuarioListadoComponent } from '../../Administracion/usuario/usuario-listado/usuario-listado.component';
// import { DetalleUsuarioComponent } from '../../Administracion/usuario/usuario-detalle/usuario-detalle.component';
// import { UsuarioRegistroComponent } from '../../Administracion/usuario/usuario-registro/usuario-registro.component';
// import { BuscarCompetidorComponent } from '../../../component/buscar-competidor/buscar-competidor.component';

// Declaramos la ruta principal inicio y sus rutas hijas
var MasterRoutes = [
    { path: '', redirectTo: 'master', pathMatch: 'full' },
    {
        path: 'master',
        component: __WEBPACK_IMPORTED_MODULE_0__mastePage_master_page_component__["a" /* MasterPage */],
        canActivate: [__WEBPACK_IMPORTED_MODULE_1__shared_auth_guard__["a" /* AuthGuard */]],
        children: __WEBPACK_IMPORTED_MODULE_2__Denuncias_denuncias_route__["a" /* DenunciasRoutes */].slice()
    }
];
//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/master-page.routes.js.map

/***/ }),

/***/ "./src/app/site/view/components/multimedia/webcam/webcam.component.css":
/***/ (function(module, exports) {

module.exports = ".inputfile {\r\n\tcolor: #3a7999;\r\n    background-color: white;\r\n    width: 25 px;\r\n    padding: 6px;\r\n    border: none ;\r\n    border-radius: 5px\r\n}\r\n\r\n.indigo-btn {\r\n border: solid ;\r\n background: #3a7999;\r\n color: white;\r\n padding: 5px;\r\n font-size: 14px;\r\n border-radius: 5px;\r\n position: relative;\r\n -webkit-box-sizing: border-box;\r\n         box-sizing: border-box;\r\n -webkit-transition: all 500ms ease;\r\n transition: all 500ms ease;\r\n}\r\n\r\n.indigo-btn:before {\r\n content:'';\r\n position: absolute;\r\n top: 0px;\r\n left: 0px;\r\n width: 0px;\r\n height: 42px;\r\n background: rgba(255,255,255,0.3);\r\n border-radius: 5px;\r\n -webkit-transition: all 2s ease;\r\n transition: all 2s ease;\r\n}\r\n\r\n"

/***/ }),

/***/ "./src/app/site/view/components/multimedia/webcam/webcam.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"ui-g\">\n  <div class=\" ui-g-12 ui-md-12 ui-message ui-messages-error ui-corner-all\" style=\"padding:0.4em !important;\" *ngIf=\"photoValid\">\n    Fotografía requerida tome o seleccione una.\n  </div>\n  <div class=\"ui-g-6 ui-md-6\" style=\"text-align:center\">\n    <video #video width=\"320\" height=\"240\" autoplay>\n      Your browser does not support the video tag.\n    </video>\n    <div class=\"ui-g\">\n      <div class=\"ui-g-12 \" style=\"text-align:center\">\n        <button class=\"indigo-btn\" type=\"button\" (click)=\"capture()\" *ngIf=\"existCam\">Capturar</button>\n      </div>\n      <div class=\"ui-g-12\" style=\"text-align:center\">\n        <input class=\"inputfile\" type=\"file\" (change)=\"fileEvent($event)\" accept=\"image/*\" />\n      </div>\n    </div>\n  </div>\n  <div class=\"ui-g-12 ui-md-6\" style=\"text-align:center\">\n    <canvas #canvas width=\"290\" height=\"320\"></canvas>\n  </div>\n</div>"

/***/ }),

/***/ "./src/app/site/view/components/multimedia/webcam/webcam.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return WebcamComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var WebcamComponent = /** @class */ (function () {
    function WebcamComponent() {
        this.visible = true;
        this.photoValid = false;
        this.photoStade = false;
        this.existCam = true;
        this.clearData = false;
        this.PrivilegiosIdsOut = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["EventEmitter"]();
        this.restore = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["EventEmitter"]();
        this.base64 = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["EventEmitter"]();
    }
    WebcamComponent.prototype.ngAfterViewInit = function () {
        var _this = this;
        this._video = this.video.nativeElement;
        this._canvas = this.canvas.nativeElement;
        if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
            navigator.mediaDevices.getUserMedia({ video: true })
                .then(function (stream) {
                _this._video.src = window.URL.createObjectURL(stream);
                _this._video.play();
                _this._stream = stream;
            }, function (error) {
                _this._video.poster = '/assets/erpHammer/images/webcam.jpg';
                _this.existCam = false;
            });
        }
    };
    WebcamComponent.prototype.ngOnChanges = function (changes) {
        var chng = changes['bandera'];
        var banderaValue = JSON.stringify(chng.currentValue);
        if (banderaValue === 'true') {
            if (this.bandera && !this.PrivilegiosIdsInput) {
                this.onValid();
            }
        }
    };
    WebcamComponent.prototype.capture = function () {
        this.visible = false;
        this.context = this._canvas.getContext('2d');
        this.context.drawImage(this._video, 0, 0, 320, 240);
        var data = this._canvas.toDataURL('image/png');
        this.photoStade = true;
    };
    WebcamComponent.prototype.fileEvent = function (fileInput) {
        var _this = this;
        this.context = this._canvas.getContext('2d');
        var file = fileInput.target.files[0];
        var fileName = file.name;
        var img = new Image;
        img.onload = function () {
            _this.context.drawImage(img, 0, 0, 300, 240); // 320,240
            _this.photoStade = true;
        };
        img.src = URL.createObjectURL(file);
    };
    WebcamComponent.prototype.onValid = function () {
        this.imgString = this._canvas.toDataURL('image/png');
        this.photoValid = (!this.photoStade);
        if (!this.photoValid) {
            this.base64.emit(this.imgString);
        }
        else {
            this.restore.emit(false);
        }
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])('video'),
        __metadata("design:type", Object)
    ], WebcamComponent.prototype, "video", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])('canvas'),
        __metadata("design:type", Object)
    ], WebcamComponent.prototype, "canvas", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Array)
    ], WebcamComponent.prototype, "PrivilegiosIdsInput", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], WebcamComponent.prototype, "bandera", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], WebcamComponent.prototype, "clearData", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Output"])(),
        __metadata("design:type", Object)
    ], WebcamComponent.prototype, "PrivilegiosIdsOut", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Output"])(),
        __metadata("design:type", Object)
    ], WebcamComponent.prototype, "restore", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], WebcamComponent.prototype, "entrada", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Output"])(),
        __metadata("design:type", Object)
    ], WebcamComponent.prototype, "base64", void 0);
    WebcamComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-webcam',
            template: __webpack_require__("./src/app/site/view/components/multimedia/webcam/webcam.component.html"),
            styles: [__webpack_require__("./src/app/site/view/components/multimedia/webcam/webcam.component.css")],
            encapsulation: __WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewEncapsulation"].None
        }),
        __metadata("design:paramtypes", [])
    ], WebcamComponent);
    return WebcamComponent;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/webcam.component.js.map

/***/ }),

/***/ "./src/app/site/view/components/topbar/tabbar.component.css":
/***/ (function(module, exports) {

module.exports = ".logoCodesur {\r\n    display: inline-block;\r\n    vertical-align: middle;\r\n    width: 180px;\r\n    height: 40px;\r\n    background: url('hammerLogoH.cdffb9733b25bab8d699.png') top left no-repeat;\r\n    background-size: 180px 40px;\r\n}\r\n"

/***/ }),

/***/ "./src/app/site/view/components/topbar/tabbar.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"topbar clearfix\">\r\n        <div class=\"topbar-left\">\r\n            <div class=\"logoCodesur\"></div>\r\n        </div>\r\n        <div class=\"topbar-right\">\r\n            <a id=\"menu-button\" href=\"#\" (click)=\"app.onMenuButtonClick($event)\">\r\n                <i></i>\r\n            </a>\r\n    \r\n            <a id=\"topbar-menu-button\" href=\"#\" (click)=\"app.onTopbarMenuButtonClick($event)\">\r\n                \r\n            </a>\r\n            <ul class=\"topbar-items animated fadeInDown\" [ngClass]=\"{'topbar-items-visible': app.topbarMenuActive}\">\r\n                <li #profile class=\"profile-item\" *ngIf=\"app.profileMode==='top'||app.isHorizontal()\"\r\n                    [ngClass]=\"{'active-top-menu':app.activeTopbarItem === profile}\">\r\n                    <a href=\"#\" (click)=\"app.onTopbarItemClick($event,profile)\">\r\n                        <div class=\"profile-image\"></div>\r\n                        <span class=\"topbar-item-name\">Jane Williams</span>\r\n                    </a>\r\n    \r\n                    <ul class=\"ultima-menu animated fadeInDown\">\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">person</i>\r\n                                <span>Profile</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">security</i>\r\n                                <span>Privacy</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">settings_applications</i>\r\n                                <span>Settings</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">power_settings_new</i>\r\n                                <span>Logout</span>\r\n                            </a>\r\n                        </li>\r\n                    </ul>\r\n                </li>\r\n                <!--<li #settings [ngClass]=\"{'active-top-menu':app.activeTopbarItem === settings}\">\r\n                    <a href=\"#\" (click)=\"app.onTopbarItemClick($event,settings)\">\r\n                        <i class=\"topbar-icon material-icons\">settings</i>\r\n                        <span class=\"topbar-item-name\">Settings</span>\r\n                    </a>\r\n                    <ul class=\"ultima-menu animated fadeInDown\">\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">palette</i>\r\n                                <span>Change Theme</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">favorite_border</i>\r\n                                <span>Favorites</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">lock</i>\r\n                                <span>Lock Screen</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">wallpaper</i>\r\n                                <span>Wallpaper</span>\r\n                            </a>\r\n                        </li>\r\n                    </ul>\r\n                </li>\r\n                <li #messages [ngClass]=\"{'active-top-menu':app.activeTopbarItem === messages}\">\r\n                    <a href=\"#\" (click)=\"app.onTopbarItemClick($event,messages)\">\r\n                        <i class=\"topbar-icon material-icons animated swing\">message</i>\r\n                        <span class=\"topbar-badge animated rubberBand\">5</span>\r\n                        <span class=\"topbar-item-name\">Messages</span>\r\n                    </a>\r\n                    <ul class=\"ultima-menu animated fadeInDown\">\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\" class=\"topbar-message\">\r\n                                <img src=\"assets/layout/images/avatar1.png\" width=\"35\" />\r\n                                <span>Give me a call</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\" class=\"topbar-message\">\r\n                                <img src=\"assets/layout/images/avatar2.png\" width=\"35\" />\r\n                                <span>Sales reports attached</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\" class=\"topbar-message\">\r\n                                <img src=\"assets/layout/images/avatar3.png\" width=\"35\" />\r\n                                <span>About your invoice</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\" class=\"topbar-message\">\r\n                                <img src=\"assets/layout/images/avatar2.png\" width=\"35\" />\r\n                                <span>Meeting today at 10pm</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\" class=\"topbar-message\">\r\n                                <img src=\"assets/layout/images/avatar4.png\" width=\"35\" />\r\n                                <span>Out of office</span>\r\n                            </a>\r\n                        </li>\r\n                    </ul>\r\n                </li>\r\n                <li #notifications [ngClass]=\"{'active-top-menu':app.activeTopbarItem === notifications}\">\r\n                    <a href=\"#\" (click)=\"app.onTopbarItemClick($event,notifications)\">\r\n                        <i class=\"topbar-icon material-icons\">timer</i>\r\n                        <span class=\"topbar-badge animated rubberBand\">4</span>\r\n                        <span class=\"topbar-item-name\">Notifications</span>\r\n                    </a>\r\n                    <ul class=\"ultima-menu animated fadeInDown\">\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">bug_report</i>\r\n                                <span>Pending tasks</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">event</i>\r\n                                <span>Meeting today at 3pm</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">file_download</i>\r\n                                <span>Download documents</span>\r\n                            </a>\r\n                        </li>\r\n                        <li role=\"menuitem\">\r\n                            <a href=\"#\">\r\n                                <i class=\"material-icons\">flight</i>\r\n                                <span>Book flight</span>\r\n                            </a>\r\n                        </li>\r\n                    </ul>\r\n                </li>\r\n                <li #search class=\"search-item\" [ngClass]=\"{'active-top-menu':app.activeTopbarItem === search}\"\r\n                    (click)=\"app.onTopbarItemClick($event,search)\">\r\n                    <span class=\"md-inputfield\">\r\n                        <input type=\"text\" pInputText>\r\n                        <label>Search</label>\r\n                        <i class=\"topbar-icon material-icons\">search</i>\r\n                    </span>\r\n                </li>-->\r\n            </ul>\r\n        </div>\r\n        \r\n    </div>"

/***/ }),

/***/ "./src/app/site/view/components/topbar/tabbar.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppTopBar; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__mastePage_master_page_component__ = __webpack_require__("./src/app/site/view/components/mastePage/master-page.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};


var AppTopBar = /** @class */ (function () {
    function AppTopBar(app) {
        this.app = app;
    }
    var _a;
    AppTopBar = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-topbar',
            template: __webpack_require__("./src/app/site/view/components/topbar/tabbar.component.html"),
            styles: [__webpack_require__("./src/app/site/view/components/topbar/tabbar.component.css")]
        })
        // tslint:disable-next-line:component-class-suffix
        ,
        __param(0, Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Inject"])(Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["forwardRef"])(function () { return __WEBPACK_IMPORTED_MODULE_1__mastePage_master_page_component__["a" /* MasterPage */]; }))),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__mastePage_master_page_component__["a" /* MasterPage */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__mastePage_master_page_component__["a" /* MasterPage */]) === "function" && _a || Object])
    ], AppTopBar);
    return AppTopBar;
}());

//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/tabbar.component.js.map

/***/ }),

/***/ "./src/main.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser_dynamic__ = __webpack_require__("./node_modules/@angular/platform-browser-dynamic/@angular/platform-browser-dynamic.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("./node_modules/@angular/core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_app_module__ = __webpack_require__("./src/app/app.module.ts");



Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["enableProdMode"])();
// if (environment.production) {
//   enableProdMode();
// }
Object(__WEBPACK_IMPORTED_MODULE_0__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_2__app_app_module__["a" /* AppModule */]);
//# sourceMappingURL=C:/ProyectoX/HamPresentation/erpHammerClient/src/main.js.map

/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("./src/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map