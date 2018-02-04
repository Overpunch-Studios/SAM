<?php

namespace App\Http\Controllers;

use App\Device;

class DeviceControllerApi extends Controller
{
    public function index() {
        $devices = Device::with('user')->get();

        return $devices;
    }

    public function show($id) {
        $device = Device::with('user')->find($id);

        return $device;
    }
}
