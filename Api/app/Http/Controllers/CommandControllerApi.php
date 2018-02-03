<?php

namespace App\Http\Controllers;

use App\Chat;
use Illuminate\Http\Request;

class CommandControllerApi extends Controller
{
    public function show($id) {
        $command = Chat::find($id);

        return $command;
    }
}
