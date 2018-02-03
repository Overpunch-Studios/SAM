<?php

namespace App\Http\Controllers;

use App\Device;
use Illuminate\Http\Request;

class DeviceControllerApi extends Controller
{
    public function show($id) {
        $device = Device::with('user')->find($id);

        return $device;
    }
}
