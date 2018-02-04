<?php

namespace App\Http\Controllers;

use App\Device;
use App\User;
use Illuminate\Http\Request;

class DeviceControllerApi extends Controller
{
    public function index(Request $request) {
        $user = User::where('api_token', $request->api_token)->first();

        $devices = Device::with('user')->where('user_id', $user->id)->get();
        if ($user->accountsubscription >= 10) {
            $devices = Device::with('user')->get();
        }

        return $devices;
    }

    public function range(Request $request) {
        $user = User::where('api_token', $request->api_token)->first();

        $devices = Device::with('user')->where('user_id', $user->id)->get();
        if ($user->accountsubscription >= 10) {
            $devices = Device::with('user')->get();
        }

        $ids = "";

        foreach ($devices as $device)
        {
            $ids .= $device->id . ',';
        }

        $ids = rtrim($ids, ',');

        $result = ['ids'=>$ids];

        return $result;
    }

    public function show($id) {
        $device = Device::with('user')->find($id);

        return $device;
    }
}
