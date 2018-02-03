<?php

use Illuminate\Http\Request;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::middleware('auth:api')->get('/user', function (Request $request) {
    return $request->user();
});

Route::post('register', 'Auth\RegisterController@register');
Route::get('register', function() {
    return redirect('/');
});
Route::post('login', 'Auth\LoginController@login');
Route::get('login', function() {
    return redirect('/');
});
Route::post('logout', 'Auth\LoginController@logout');
Route::get('logout', function() {
    return redirect('/');
});

Route::group(['middleware' => 'auth:api'], function() {
    Route::get('/devices/{id}', 'DeviceControllerApi@show');

    Route::get('/commands/{id}', 'CommandControllerApi@show');
});
